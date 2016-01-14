using UnityEngine;
using System.Collections;

public class JM_ItemPropertyGeneration : MonoBehaviour
{
    public int StatRolls;
    public int StatMinimum;
    public int StatMaximum;

    public int ChanceofTraits;
    public int MinimumTraitRolls;
    public int MaximumTraitRolls;

    public string[] ChosenStat;

    public int itemHealth;
    public int itemStrength;
    public int itemDexterity;
    public int itemIntelligence;

    public string TraitSlot1;
    public string TraitSlot2;
    public string TraitSlot3;
    public string TraitSlot4;

	// Use this for initialization
	void Awake()
    {
        StatRolls = 0;          //Initialise variables to be used by child class.
        StatMinimum = 0;
        StatMaximum = 0;
        ChanceofTraits = 0;
        MinimumTraitRolls = 0;
        MaximumTraitRolls = 0;
        ChosenStat = new string[] {"Health", "Strength", "Dexterity", "Intelligence"};
        TraitSlot1 = " ";
        TraitSlot2 = " ";
        TraitSlot3 = " ";
        TraitSlot4 = " ";
	}

    public virtual void ItemStatGeneration(int Rarity)//generates the stats the item has
    {
        if (Rarity >= 0 && Rarity <= 350)
        {
            StatRolls = Random.Range(0, 1);
            StatMinimum = 1;
            StatMaximum = 2;
            ChanceofTraits = 0;
            MinimumTraitRolls = 0;
            MaximumTraitRolls = 0;
            int j;
            for(int i = 0; i < StatRolls; i++)
            {
                j = Random.Range(0, ChosenStat.Length);
                if(ChosenStat[j] == "Health")
                {
                    itemHealth = Random.Range(StatMinimum, StatMaximum) * 10;
                }
                else if(ChosenStat[j] == "Strength")
                {
                    itemStrength = Random.Range(StatMinimum, StatMaximum);
                }
                else if (ChosenStat[j] == "Dexterity")
                {
                    itemDexterity = Random.Range(StatMinimum, StatMaximum);
                }
                else if (ChosenStat[j] == "Intelligence")
                {
                    itemIntelligence = Random.Range(StatMinimum, StatMaximum);
                }

            }
        }

        else if (Rarity >= 351 && Rarity <= 600)
        {
            StatRolls = Random.Range(1, 1);
            StatMinimum = Random.Range(1, 2);
            StatMaximum = Random.Range(2, 3);
            ChanceofTraits = Random.Range(0, 1);
            if(ChanceofTraits <= 0)
            {
                MinimumTraitRolls = 0;
                MaximumTraitRolls = 0;
            }
            if (ChanceofTraits == 1)
            {
                MinimumTraitRolls = 1;
                MaximumTraitRolls = 1;
            }
            for (int i = 0; i < StatRolls; i++)
            {
                int j;

                j = Random.Range(0, ChosenStat.Length);
                if (ChosenStat[j] == "Health")
                {
                    itemHealth = Random.Range(StatMinimum, StatMaximum) * 10;
                }
                else if (ChosenStat[j] == "Strength")
                {
                    itemStrength = Random.Range(StatMinimum, StatMaximum);
                }
                else if (ChosenStat[j] == "Dexterity")
                {
                    itemDexterity = Random.Range(StatMinimum, StatMaximum);
                }
                else if (ChosenStat[j] == "Intelligence")
                {
                    itemIntelligence = Random.Range(StatMinimum, StatMaximum);
                }
            }
            ItemTraitGeneration(Random.Range(MinimumTraitRolls, MaximumTraitRolls));
        }

        else if (Rarity >= 601 && Rarity <= 750)
        {
            StatRolls = Random.Range(1,2);
            StatMinimum = Random.Range(3,5);
            StatMaximum = Random.Range(5,7);
            ChanceofTraits = Random.Range(1,1);
            if(ChanceofTraits == 1)
            {
                MinimumTraitRolls = 1;
                MaximumTraitRolls = 2;
            }
            for (int i = 0; i < StatRolls; i++)
            {
                int j;

                j = Random.Range(0, ChosenStat.Length);
                if (ChosenStat[j] == "Health")
                {
                    itemHealth = Random.Range(StatMinimum, StatMaximum) * 10;
                }
                else if (ChosenStat[j] == "Strength")
                {
                    itemStrength = Random.Range(StatMinimum, StatMaximum);
                }
                else if (ChosenStat[j] == "Dexterity")
                {
                    itemDexterity = Random.Range(StatMinimum, StatMaximum);
                }
                else if (ChosenStat[j] == "Intelligence")
                {
                    itemIntelligence = Random.Range(StatMinimum, StatMaximum);
                }
            }
            ItemTraitGeneration(Random.Range(MinimumTraitRolls, MaximumTraitRolls));
        }

        else if (Rarity >= 751 && Rarity <= 800)
        {
            StatRolls = Random.Range(2, 2);
            StatMinimum = Random.Range(4, 7);
            StatMaximum = Random.Range(7, 11);
            ChanceofTraits = Random.Range(1, 2);
            if (ChanceofTraits == 1)
            {
                MinimumTraitRolls = 1;
                MaximumTraitRolls = 1;
            }
            else if (ChanceofTraits >=2)
            {
                MinimumTraitRolls = 1;
                MaximumTraitRolls = 2;
            }
            for (int i = 0; i < StatRolls; i++)
            {
                int j;

                j = Random.Range(0, ChosenStat.Length);
                if (ChosenStat[j] == "Health")
                {
                    itemHealth = Random.Range(StatMinimum, StatMaximum) * 10;
                }
                else if (ChosenStat[j] == "Strength")
                {
                    itemStrength = Random.Range(StatMinimum, StatMaximum);
                }
                else if (ChosenStat[j] == "Dexterity")
                {
                    itemDexterity = Random.Range(StatMinimum, StatMaximum);
                }
                else if (ChosenStat[j] == "Intelligence")
                {
                    itemIntelligence = Random.Range(StatMinimum, StatMaximum);
                }
            }
            ItemTraitGeneration(Random.Range(MinimumTraitRolls, MaximumTraitRolls));
        }

        else if (Rarity >= 801 && Rarity <= 850)
        {
            StatRolls = Random.Range(2, 3);
            StatMinimum = Random.Range(7, 11);
            StatMaximum = Random.Range(11, 15);
            ChanceofTraits = Random.Range(2, 2);
            if (ChanceofTraits == 2)
            {
                MinimumTraitRolls = Random.Range(1,2);
                MaximumTraitRolls = Random.Range(2,3);
            }
            for (int i = 0; i < StatRolls; i++)
            {
                int j;

                j = Random.Range(0, ChosenStat.Length);
                if (ChosenStat[j] == "Health")
                {
                    itemHealth = Random.Range(StatMinimum, StatMaximum) * 10;
                }
                else if (ChosenStat[j] == "Strength")
                {
                    itemStrength = Random.Range(StatMinimum, StatMaximum);
                }
                else if (ChosenStat[j] == "Dexterity")
                {
                    itemDexterity = Random.Range(StatMinimum, StatMaximum);
                }
                else if (ChosenStat[j] == "Intelligence")
                {
                    itemIntelligence = Random.Range(StatMinimum, StatMaximum);
                }
            }
            ItemTraitGeneration(Random.Range(MinimumTraitRolls, MaximumTraitRolls));
        }

        else if (Rarity >= 851 && Rarity <= 875)
        {
            StatRolls = Random.Range(3, 4);
            StatMinimum = Random.Range(11, 15);
            StatMaximum = Random.Range(15, 20);
            ChanceofTraits = Random.Range(2, 3);
            if (ChanceofTraits == 2)
            {
                MinimumTraitRolls = Random.Range(2,2);
                MaximumTraitRolls = Random.Range(2,3);
            }
            else if (ChanceofTraits == 3)
            {
                MinimumTraitRolls = Random.Range(2, 3);
                MaximumTraitRolls = Random.Range(3, 4);
            }
            for (int i = 0; i < StatRolls; i++)
            {
                int j;

                j = Random.Range(0, ChosenStat.Length);
                if (ChosenStat[j] == "Health")
                {
                    itemHealth = Random.Range(StatMinimum, StatMaximum) * 10;
                }
                else if (ChosenStat[j] == "Strength")
                {
                    itemStrength = Random.Range(StatMinimum, StatMaximum);
                }
                else if (ChosenStat[j] == "Dexterity")
                {
                    itemDexterity = Random.Range(StatMinimum, StatMaximum);
                }
                else if (ChosenStat[j] == "Intelligence")
                {
                    itemIntelligence = Random.Range(StatMinimum, StatMaximum);
                }
            }
            ItemTraitGeneration(Random.Range(MinimumTraitRolls, MaximumTraitRolls));
        }

        else if (Rarity >= 876 && Rarity <= 950)//cursed items
        {
            StatRolls = Random.Range(1, 1);
            StatMinimum = Random.Range(1, 2);
            StatMaximum = Random.Range(2, 3);
            ChanceofTraits = Random.Range(0, 1);
            if (ChanceofTraits == 1)
            {
                MinimumTraitRolls = 1;
                MaximumTraitRolls = 1;
            }
            for (int i = 0; i < StatRolls; i++)
            {
                int j;

                j = Random.Range(0, ChosenStat.Length);
                if (ChosenStat[j] == "Health")
                {
                    itemHealth = Random.Range(StatMinimum, StatMaximum) * 10;
                }
                else if (ChosenStat[j] == "Strength")
                {
                    itemStrength = Random.Range(StatMinimum, StatMaximum);
                }
                else if (ChosenStat[j] == "Dexterity")
                {
                    itemDexterity = Random.Range(StatMinimum, StatMaximum);
                }
                else if (ChosenStat[j] == "Intelligence")
                {
                    itemIntelligence = Random.Range(StatMinimum, StatMaximum);
                }
            }
            ItemTraitGeneration(Random.Range(MinimumTraitRolls, MaximumTraitRolls));
        }
    }

    void ItemTraitGeneration(int TraitRolls)//generates the traits (if any) the item has.
    {
        string[] Traits = new string[] { "Burning", "Freezing", "Posion", "Shocking", "Multishot" };
        for(int i = 0; i < TraitRolls; i++)
        {
            int j;
            j = Random.Range(0, Traits.Length);
            if(Traits[j] == "Burning" || Traits[j] == "Shocking" || Traits[j] == "Posion" || Traits[j] == "Freezing" || Traits[j] == "Multishot")
            {
                if (TraitSlot1 != null)
                {
                    TraitSlot2 = Traits[j];
                }
                if (TraitSlot2 != null)
                {
                    TraitSlot3 = Traits[j];
                }
                if (TraitSlot3 != null)
                {
                    TraitSlot4 = Traits[j];
                }
                TraitSlot1 = Traits[j];               
            }
        }
    }
}
