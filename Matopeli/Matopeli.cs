using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Widgets;

public class Matopeli : PhysicsGame
{
    
    public override void Begin()
    {

        Level.Background.CreateGradient(Color.White, Color.Pink);

        // tässä luon ensimmäisen version matosesta, josta kasvaa myöhemmin vaarallinen käärme
        PhysicsObject mato = new PhysicsObject(40, 20);
        mato.Shape = Shape.Rectangle;
        mato.Mass = 10.0;
        mato.Color = Color.Green;
        Add(mato); 

        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
    }
}

