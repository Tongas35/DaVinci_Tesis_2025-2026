using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Elf : MonoBehaviour
{
    private Distance<Table> _tableOrder;
    private List<Table> _tables;
    Table assignedTable;
    FSMClient _fsmClient;
    private bool isMoving = false;
    private Vector3 targetPosition;

    
    private Image img;
    public Image globe;
    private Order _order;
    [SerializeField]
    List<Image> _orders;
   

    public GameObject beer;

    private void Start()
    {
        _fsmClient = new FSMClient();
        _fsmClient.AddState(StatesEnum.Spawn, new SpawnState(this));
        _fsmClient.AddState(StatesEnum.Consuming, new ConsumingState(this));
        _fsmClient.AddState(StatesEnum.Leaving, new LeavingState());
        _fsmClient.AddState(StatesEnum.Waiting, new WaitingState(this));
        _fsmClient.ChangeState(StatesEnum.Spawn);
        _order = new Order(_orders, transform, this);
        globe.gameObject.SetActive(false);

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
        globe.transform.position = transform.position + new Vector3(5, 12, 0);
        globe.transform.LookAt(Camera.main.transform);
        globe.transform.Rotate(0, 180, 0);

        

    }

    public void OrderActionActive(Card placedCard)
    {
        _order.OrderAction(img, placedCard, beer);

    }

    public void NotifyCardPlaced()
    {
        Debug.Log("se coloco la carta.");
        _fsmClient.ChangeState(StatesEnum.Consuming);
    }

    public IEnumerator Timer() 
    {
        yield return new WaitForSeconds(4);
        _fsmClient.ChangeState(StatesEnum.Leaving);
    }
}
