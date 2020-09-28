using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface ITargetItem
{
    void ZeroingTarget();
    IItemTarget Item { get; set; }
}

public interface ICross
{

}

public interface IMinus
{

}

public interface IHex
{

}

public interface ITriangular
{

}

public interface ICap
{
    void RemoveHolder();
}

public class Holder : MonoBehaviour,IPointerDownHandler
{
    public enum Tool
    {
        Coin,
        PliersWithTip,
        BoltWithNut,
        RodAfterPliers
    }
    private ICap cap;
    public Tool tool;
    private ITargetItem target = new TargetItem();
    private Animator animator;
    private Inventory inventory = new Inventory();

    private void Awake()
    {
        cap = GetComponentInParent<ICap>();
        animator = GetComponent<Animator>();
    }

    public IEnumerator Unscrew()
    {
        animator.SetBool("Unscrew", true);
        yield return new WaitForSeconds(3);
        cap.RemoveHolder();
        Destroy(gameObject);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        switch (target.Item)
        {
            case ICross crossTool when tool == Tool.PliersWithTip:
                inventory.AddItem<PliersItem>();
                inventory.RemoveItem<PliersWithTipItem>();
                StartCoroutine(Unscrew());
                break;
            case IMinus minusTool when tool == Tool.Coin:
                inventory.RemoveItem<CoinItem>();
                StartCoroutine(Unscrew());
                break;
            case IHex hexTool when tool == Tool.BoltWithNut:
                inventory.RemoveItem<BoltWithNutItem>();
                StartCoroutine(Unscrew());
                break;
            case ITriangular triangularTool when tool == Tool.RodAfterPliers:
                inventory.RemoveItem<RodAfterPliers>();
                StartCoroutine(Unscrew());
                break;
            default:
                print("Нет нужного инструмента");
                break;
        }
    }
}
