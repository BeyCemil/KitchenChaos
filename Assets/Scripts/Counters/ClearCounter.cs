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
            if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
            {
               //Player holding plate
               if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
               {
                  GetKitchenObject().DestroySelf();
               }
            } 
            else
            {
               if (GetKitchenObject().TryGetPlate(out plateKitchenObject))
               {
                  if (plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO()))
                  {
                     player.GetKitchenObject().DestroySelf();
                  }
               }
            }
         }
         else
         {  
            //Not Carrying
            GetKitchenObject().SetKitchenObjectParent(player);       
         }
      }
   }
}
