using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Widgets;

public class Matopeli : PhysicsGame
{
    //TODO KÄÄRME ON SAATAVA LIIKKEEELLE 
    //OHJELMAN ON PÄIVITYTTÄVÄ NOPEALLA AIKAVÄLILLÄ, jotta käärme voi liikkua? 
    //LISTAN PALOJEN ON LIIKUTTAVA SAMAA REITTIÄ ... EN OSAA TEHDÄ! 
    //tarvitaan if-lauseet, että jos käärme syö poikasen, se kasvaa. Jos törmää seiniin, peli loppuu ja jos käärme törmää itseensä, peli loppuu
    //Lopuksi vielä räjähdysefektit ja pistelaskurit 
    //Miksen saa taustaväriä muutettua? 


    // lisätään ruudukko, koska matopeliä on järkevintä pelata ruudukossa. Ruutu == yksi ruutu
    //TaustanLeveys kuvaa, montako ruutua pelissä on leveyssuuntaan
    //TaustanKorkeus kuvaa, montako ruutua pelissä on korkeussuuntaan
    const int Ruutu = 40;
    const int KentanLeveys = 37;
    const int KentanKorkeus = 27;

    //mato koostetaan palasista, jotka tehdään listamuodossa. 

    List<GameObject> kaarmepalat = new List<GameObject>();
    //TODO mato pitäisi saada liikkumaan ylös, alas, vasemmalle ja oikealle. 

    Direction suunta;

    //pitäisi luoda pikkukäärmeitä, joita käärme sitten popsii

    GameObject pikkumato;


    public override void Begin()
    {
        PelinAloitus();
    }

    //pelin alkaessa pelikentän on oltava tyhjä, paitsi että siinä on oltava tietyn kokoinen mato. 
    void PelinAloitus()
    {
        //kenttä pitää tietysti määritellä ensin 
        Level.Height = KentanKorkeus * Ruutu;
        Level.Width = KentanLeveys * Ruutu;
        Level.CreateBorders();
        Level.Background.CreateGradient(Color.White, Color.Pink);
        

        kaarmepalat.Clear(); //kun peli alkaa, käärmeen on oltava pienikokoinen
        suunta = Direction.Up; //mato liikkuu heti pelin alkaessa ylöspäin
        ClearAll(); //pelikenttä tyhjenee

        //luodaan pikkukäärmeitä ruuaksi isolle käärmeelle 
        pikkumato = new GameObject(Ruutu, Ruutu);
        pikkumato.Color = Color.Green;
        Add(pikkumato); 

        //käärmeen paloja pitää luoda listaan

        LuoKaarme(7 * Ruutu, 3 * Ruutu);
        LuoKaarme(6 * Ruutu, 3 * Ruutu);
        LuoKaarme(5 * Ruutu, 3 * Ruutu);
        LuoKaarme(4 * Ruutu, 3 * Ruutu);
        LuoKaarme(3 * Ruutu, 3 * Ruutu);

        AsetaOhjaimet();

    }

    //aliohjelmassa luodaan käärme palasista, jotka lisätään listan paikkaan 0
    void LuoKaarme(double x, double y)
    {
        GameObject palanen = new GameObject(Ruutu, Ruutu);
        palanen.Y = y;
        palanen.X = x;
        kaarmepalat.Insert(0, palanen);
        palanen.Color = Color.Green;
        Add(palanen); 
    }
    void AsetaOhjaimet()
    {
        Keyboard.Listen(Key.Right, ButtonState.Pressed, UusiSuunta, null, Direction.Right);
        Keyboard.Listen(Key.Left, ButtonState.Pressed, UusiSuunta, null, Direction.Left);
        Keyboard.Listen(Key.Up, ButtonState.Pressed, UusiSuunta, null, Direction.Up);
        Keyboard.Listen(Key.Down, ButtonState.Pressed, UusiSuunta, null, Direction.Down);
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
    }

    private void UusiSuunta(Direction vaihdaSuunta)
    {
        suunta = vaihdaSuunta;
    }

    }




