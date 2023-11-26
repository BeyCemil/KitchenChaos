using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
   [SerializeField] private CuttingRecipeSO[] cuttingRecipeSOArray;
   public override void Interact(Player player)
   {

      if (!HasKitchenObject())
      {
         //No Object
         if (player.HasKitchenObject())
         {
            //Player Carrying
            if (HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO()))
            {
               player.GetKitchenObject().SetKitchenObjectParent(this);
            }
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

   public override void InteractAlternate(Player player)
   {
      if (HasKitchenObject() && HasRecipeWithInput(GetKitchenObject().GetKitchenObjectSO()))
      {
         KitchenObjectSO outputKitchenObjectSO = GetOutputForInput(GetKitchenObject().GetKitchenObjectSO());
         GetKitchenObject().DestroySelf();

         KitchenObject.SpawnKitchenObject(outputKitchenObjectSO, this);
      }
   }

   private bool HasRecipeWithInput(KitchenObjectSO inputKitchenObjectSO)
   {
      foreach (CuttingRecipeSO cuttingRecipeSO in cuttingRecipeSOArray)
      {
         if (cuttingRecipeSO.input == inputKitchenObjectSO)
         {
            return true;
         }
      }
      return false;
   }

   private KitchenObjectSO GetOutputForInput(KitchenObjectSO inputKitchenInputSO)
   {
      foreach (CuttingRecipeSO cuttingRecipeSO in cuttingRecipeSOArray)
      {
         if (cuttingRecipeSO.input == inputKitchenInputSO)
         {
            return cuttingRecipeSO.output;
         }
      }
      return null;
   }
}
