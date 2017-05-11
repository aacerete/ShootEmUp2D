using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerEntity : Entity {

    public Slider healthBar;

    // Use this for initialization
    public override void ModifyHealth(int amount)
    {
        base.ModifyHealth(amount);
        this.healthBar.value = health;
    }
}
