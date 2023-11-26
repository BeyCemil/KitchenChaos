using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{



   [SerializeField] private KitchenObjectSO kitchenObjectSO;

   public override void Interact(Player player)
   {
      if (!HasKitchenObject())
      {
         //No Object
         if (player.HasKitchenObject())
         {
            //Player Carrying
            player.GetKitchenObject().SetKitchenObjectParent(this);
         }
         else
         {
            //Player not Carrying
         }
      }
      else
      {
         //Object
         if (player.HasKitchenObject())
         {
            //Carrying
         }
         else
         {
            //Not Carrying
            GetKitchenObject().SetKitchenObjectParent(player);       
         }
      }
   }
}
