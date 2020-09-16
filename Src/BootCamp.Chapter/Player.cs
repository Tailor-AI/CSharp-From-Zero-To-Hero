﻿using BootCamp.Chapter.Items;
using System;
using System.Linq;

namespace BootCamp.Chapter
{
    /// <summary>
    /// Task: simulate a player who has an inventory.
    /// Player can add or remove items from inventory.
    ///
    /// Extra task: player has equipement and maximum weight he/she can carry.
    /// Player should not be able to take items if already at maximum weight.
    /// Player should expose TotalAttack, TotalDefense stats.
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Everyone can carry this much weight at least.
        /// </summary>
        private const int baseCarryWeight = 30;

        private string _name;
        private int _hp;

        /// <summary>
        /// Each point of strength allows extra 10 kg to carry.
        /// </summary>
        private int _strenght;

        /// <summary>
        /// Player items. There can be multiple of items with same name.
        /// </summary>
        private Inventory _inventory;
        /// <summary>
        /// Needed only for the extra task.
        /// </summary>
        private Equipment _equipment;

        private float _totalAttack;
        private float _totalDefense;

        public float GetTotalAttack()
        {
            _totalAttack = _equipment.GetTotalAttack();
            return _totalAttack;
        }
        
        public float GetTotalDefense()
        {
            _totalDefense = _equipment.GetTotalDefense();
            return _totalDefense;
        }

        public Player()
        {
            _inventory = new Inventory();
            _equipment = new Equipment();
        }

        public Player(string name, int hp, int strength)
        {
            if (strength >= 0 && strength <= 10)
            {
                _strenght = strength;
            }

            if (!string.IsNullOrEmpty(name))
            {
                _name = name;
            }

            if (hp >= 0 && hp <= 10)
            {
                _hp = hp;
            }

            _inventory = new Inventory();
            _equipment = new Equipment();
        }

        /// <summary>
        /// Gets all items from player's inventory
        /// </summary>
        public Item[] GetItems()
        {
            return _inventory.GetItems();
        }

        /// <summary>
        /// Adds item to player's inventory if player can carry extra item weight.
        /// </summary>
        public void AddItem(Item item)
        {
            float remainingCarryWeight = GetTotalCarryWeight() - GetTotalInventoryWeight();

            if(remainingCarryWeight >= item.GetWeight())
            {
                _inventory.AddItem(item);
            }
        }

        public void Remove(Item item)
        {
            _inventory.RemoveItem(item);
        }

        /// <summary>
        /// Gets items with matching name.
        /// </summary>
        /// <param name="name"></param>
        public Item[] GetItems(string name)
        {
            return _inventory.GetItems(name);
        }

        public float GetTotalInventoryWeight()
        {
            if(_inventory.GetItems().Length == 0)
            {
                return 0;
            }
            return _inventory.GetItems().Sum(x => x.GetWeight());
        }

        public int GetTotalCarryWeight()
        {
            return baseCarryWeight + _strenght * 10;
        }

        #region Extra challenge: Equipment
        // Player has equipment.
        // Various slots of equipment can be equiped and unequiped.
        // When a slot is equiped, it contributes to total defense
        // and total attack.
        // Implement equiping logic and total defense/attack calculation.
        public void Equip(Weapon weapon)
        {
            _equipment.SetWeapon(weapon);
            _totalAttack = _equipment.GetTotalAttack();
        }

        public void Equip(Headpiece head)
        {
            _equipment.SetHead(head);
            _totalDefense = _equipment.GetTotalDefense();
        }

        public void Equip(Chestpiece head)
        {
            _equipment.SetChest(head);
            _totalDefense = _equipment.GetTotalDefense();
        }

        public void Equip(Shoulderpiece head, bool isLeft)
        {
            if (isLeft)
            {
                _equipment.SetLeftShoulder(head);
                _totalDefense = _equipment.GetTotalDefense();
            }
            else
            {
                _equipment.SetRightShoulder(head);
                _totalDefense = _equipment.GetTotalDefense();
            }
        }

        public void Equip(Legspiece head)
        {
            _equipment.SetLeg(head);
            _totalDefense = _equipment.GetTotalDefense();
        }

        public void Equip(Armpiece head, bool isLeft)
        {
            if (isLeft)
            {
                _equipment.SetLeftArmp(head);
                _totalDefense = _equipment.GetTotalDefense();
            }
            else
            {
                _equipment.SetRightArm(head);
                _totalDefense = _equipment.GetTotalDefense();
            }
        }

        public void Equip(Gloves head)
        {
            _equipment.SetGloves(head);
            _totalDefense = _equipment.GetTotalDefense();
        }
        #endregion
        public override string ToString()
        {
            return string.Format($"Player: {_name} has strength {_strenght} and hp {_hp}.{Environment.NewLine}" +
                $"{_name} can carry a weight of {GetTotalCarryWeight() - GetTotalInventoryWeight()} out of a capacity of {GetTotalCarryWeight()}.{Environment.NewLine}" +
                $"{_name} has the following equipment: {_equipment}{Environment.NewLine}" +
                $"{_name} has {GetTotalAttack()} attackpoints and {GetTotalDefense()} defensepoints.");
        }
    }
}
