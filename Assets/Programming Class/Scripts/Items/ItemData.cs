using UnityEngine;

public static class ItemData
{
    
    public static Item CreateItem(int itemID)
    {
  
 string name = "";
int value = 0;
 string description = "";    
string icon = "";
 string mesh = "";    
 ItemType type = ItemType.Weapon;
        int heal = 0;
        int damage = 0;
        int armour = 0;
        int amount = 0;

        switch (itemID)
        {

            #region  Weapon 0-99
            case 0:
                name = "Short Sword";
                value = 20;
                description = "Pointy";
                icon = "ShortSword_Icon";
                mesh = "ShortSword_Mesh";
                type = ItemType.Weapon;
                damage = 15;          
                amount = 1;
                break;

            case 1:
                name = "Long Sword";
                value = 50;
                description = "Longer Pointy";
                icon = "LongSword_Icon";
                mesh = "LongSword_Mesh";
                type = ItemType.Weapon;
                damage = 25;
                amount = 1;
                break;
            case 2:
                name = "Axe";
                value = 45;
                description = "Swing Me";
                icon = "Axe_Icon";
                mesh = "Axe_Mesh";
                type = ItemType.Weapon;
                damage = 20;
                amount = 1;
                break;
            #endregion
            #region Apparel 100-199
            case 100:
                name = "Wizards Hat";
                value = 30;
                description = "You're a wizard";
                icon = "WizardsHat_Icon";
                mesh = "WizardsHat_Mesh";
                type = ItemType.Apparel;
                armour = 15;
                amount = 1;
                break;
            case 101:
                name = "Fur Hat";
                value = 20;
                description = "Comfy";
                icon = "FurHat_Icon";
                mesh = "FurHat_Mesh";
                type = ItemType.Apparel;
                armour = 10;
                amount = 1;
                break;
            case 102:
                name = "Full Helm";
                value = 40;
                description = "Good Protection";
                icon = "FullHelm_Icon";
                mesh = "FullHelm_Mesh";
                type = ItemType.Apparel;
                armour = 30;
                amount = 1;
                break;


            #endregion
            #region Quest 200 -299
            case 200:
                name = "Candy";
                value = 1;
                description = "Sweet";
                icon = "Candy_Icon";
                mesh = "Candy_Mesh";
                type = ItemType.Quest;
                amount = 1;
                break;
            case 201:
                name = "Shell";
                value = 1;
                description = "Home";
                icon = "Shell_Icon";
                mesh = "Shell_Mesh";
                type = ItemType.Quest;
                amount = 1;
                break;
            case 202:
                name = "Bones";
                value = 1;
                description = "Creepy";
                icon = "Bones_Icon";
                mesh = "Bones_Mesh";
                type = ItemType.Quest;
                amount = 1;
                break;
            #endregion
            #region Currency 300-399
            #endregion
            #region Consumable 400-499
            case 400:
             name = "Meat";
        value = 15;
         description = "YUM";
         icon = "Meat_Icon";
         mesh = "Meat_Mesh";
        type = ItemType.Consumable;
         heal = 10;
        damage = 0;
         armour = 0;
         amount = 1;
                break;
            case 401:
                name = "Chicken";
                value = 10;
                description = "White Meat";
                icon = "Chicken_Icon";
                mesh = "Chicken_Mesh";
                type = ItemType.Consumable;
                heal = 5;
                damage = 0;
                armour = 0;
                amount = 1;
                break;
            case 402:
                name = "Bread";
                value = 1;
                description = "Fibrous";
                icon = "Bread_Icon";
                mesh = "Bread_Mesh";
                type = ItemType.Consumable;
                heal = 1;
                damage = 0;
                armour = 0;
                amount = 1;
                break;
            #endregion
            default:
                itemID = 4;
                name = "Apple";
                value = 1;
                description = "cronch";
                icon = "Apple_Icon";
                mesh = "Apple_Mesh";
                type = ItemType.Consumable;
                heal = 5;
                amount = 1;
                break;

        }
    Item temp = new Item
        {
            Name = name,
            Description = description,
            ID = itemID,
            Value = value,
            Damage = damage,
            Armour = armour,
            Amount = amount,
            Heal = heal,
        Type = type,
        Mesh = Resources.Load("Prefabs/" + mesh)as GameObject,
        Icon = Resources.Load("Icon/"+ icon) as Texture2D
           

        };
        return temp; 

}


}
