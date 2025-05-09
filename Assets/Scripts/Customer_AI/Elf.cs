#nullable enable
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Elf : ClientBase
{
    private Distance<Table>? _tableOrder;
    private List<Table>? _tables;
    public int countGood;
    public int tolerance;
    public ElfChat? elfChat;
    [HideInInspector]
    public Table? assignedTable;
    FSMClient _fsmClient;
    private bool isMoving = false;
    private Vector3 targetPosition;
    private Vector3 targetPositionExit;
    [HideInInspector]
    public Image? img;
    [SerializeField]
    List<Image>? imageChaosList;
    public Image globe;
    private Order _order;
    [SerializeField]
    List<Image> _orders;
    [HideInInspector]
    public Table table;

    public GameObject beer;

    private void Start()
    {
         table = TableManager.instance.GetRandomAvailableTable();
        _fsmClient = new FSMClient();
        _fsmClient.AddState(StatesEnum.Spawn, new SpawnState(this, table));
        _fsmClient.AddState(StatesEnum.Waiting, new WaitingState(this));
        _fsmClient.AddState(StatesEnum.Consuming, new ConsumingState(this));
        _fsmClient.AddState(StatesEnum.Leaving, new LeavingState(this, table));
        _fsmClient.AddState(StatesEnum.Chaos, new ChaosState(this, table));
        _fsmClient.ChangeState(StatesEnum.Spawn);
        _order = new Order(_orders, transform, this, imageChaosList);
        globe.gameObject.SetActive(false);
        targetPositionExit = new Vector3(-19.5f, -5.4f, 57.92f);
        beer.SetActive(false);
    }

    private void Update()
    {
        _fsmClient.VirtualUpdate();
    }

    public void GoToTable(Table table)
    {
        targetPosition = table.transform.position;
        isMoving = true;
        
    }

    public void MoveToTarget()
    {
        if (!isMoving) return;
        Vector3 dir = (targetPosition - transform.position).normalized;

        transform.position += dir * 10 * Time.deltaTime;
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            isMoving = false;

            _fsmClient.ChangeState(StatesEnum.Waiting);
        }
    }

    public void Globe()
    {
        img = _order.OrderList();
        globe.gameObject.SetActive(true);
        img.gameObject.SetActive(true);
        globe.transform.position = transform.position + new Vector3(2.5f, 5, 0);
        globe.transform.LookAt(Camera.main.transform);
        globe.transform.Rotate(0, 180, 0);
    }

    public void GlobeChaos() 
    {
        img = _order.ChaosOne();
        globe.gameObject.SetActive(true);
        img.gameObject.SetActive(true);
        globe.transform.position = transform.position + new Vector3(2.5f, 5, 0);
        globe.transform.LookAt(Camera.main.transform);
        globe.transform.Rotate(0, 180, 0);
        
    }
    public void OrderActionActive(Card placedCard)
    {
       var isGood = _order.OrderAction(img, placedCard, beer);

        if (isGood) 
        {
            countGood++;
            
        }
        else
        {
            tolerance--;
        }
    }

    
    public void EnteredWaiting()
    {
        Card.onCardPlaced += OnCardPlaced;
    }

    public void ExitedWaiting()
    {
        Card.onCardPlaced -= OnCardPlaced;
    }
    public void EnteredWaiting2()
    {
        Card.onCardPlaced += OnCardPlaced2;
    }
    public void ExitedWaiting2()
    {
        Card.onCardPlaced -= OnCardPlaced2;
    }



    private void OnCardPlaced(Card card, Elf elf)
    {
        if (elf != this) return; 

        Debug.Log("Carta recibida por el elfo correcto.");
        OrderActionActive(card);
        _fsmClient.ChangeState(StatesEnum.Consuming);
    }

    private void OnCardPlaced2(Card card, Elf elf)
    {
        if (elf != this) return;

        Debug.Log("Carta recibida por el elfo correcto.");
        OrderActionActive(card);
        elf.gameObject.SetActive(false);
        elf.transform.position = targetPositionExit;
        globe.gameObject.SetActive(false);
        
        
    }

    public IEnumerator ExitBar() 
    {
        beer.SetActive(true);
        yield return new WaitForSeconds(5f);
        beer.SetActive(false);
        

        


    }

    public IEnumerator NotExit() 
    {

        yield return new WaitForSeconds(5f);

        while (Vector3.Distance(transform.position, targetPositionExit) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPositionExit,
                10 * Time.deltaTime
            );
            yield return null;
        }

        Debug.Log("elfo salio del bar");
        gameObject.SetActive(false);
        _fsmClient.ChangeState(StatesEnum.Spawn);
    }
    public override void ActivateClient()
    {
        gameObject.SetActive(true);
    }
}
