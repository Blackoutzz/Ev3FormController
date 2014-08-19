using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lego.Ev3.Core;
using Lego.Ev3.Desktop;

namespace EV3Controller
{
     class Server
    {

        //-----------------------------------------------------//
        // Valeur des capteurs. // Sensor's values              //
        //---------------------------------//------------------//
        private int A;                      // Sensor Input A   //
        private int B;                      // Sensor Input B   //
        private int C;                      // Sensor Input C   //
        private int D;                      // Sensor Input D   //
        private int S1;                     // Sensor Input 1   //
        private int S2;                     // Sensor Input 2   //
        private int S3;                     // Sensor Input 3   //
        private int S4;                     // Sensor Input 4   //
        //---------------------------------//------------------//
        //Variables du robot //Robot's variables               //
        //---------------------------------------------------//
        private Brick EV3;
        private bool Connected;
        private Task Work;
        private int speed = 100;
        //Propriété du robot qui gère la vitesse // Robot's speed property
        public int Speed
        {
            get { return this.speed; }
            set { this.speed = value; }
        }

        //Constructeur // Constructor
        public Server(string IpRobot)
        {
            //Connection en mode USB
            //Brick EV3 = new Brick(new UsbCommunication());

            //Connection en mode Bluetooth
            //Brick EV3 = new Brick(new BluetoothCommunication("COM 1"));
            
            //Connection en mode Wifi 
           //Création de la brick en mémoire
            EV3 = new Brick(new NetworkCommunication(IpRobot)); //Ip 10.2.0.59
           //Essaie de connection  
            Work = Connect();
            Work.Wait();
        }

           //----------------------------------------------------------//
          //  Methode du robot.  // Robot's Methode                     //
         //-----------------------------------------------------------//
        //Retourne si le robot est connecter ou pas // return if the connection is working
        public bool GetConnectionStatus()
        {
            return Connected;
        }
        //Envoie une commande au robot // Send a movement command to the robot
        public void SendCommand(string Command)
        {
            switch (Command)
            {
                case "a":
                    Work = TurnLeft(1, this.speed);
                    Work.Wait();
                    break;
                case "d":
                    Work = TurnRight(1, this.speed);
                    Work.Wait();
                    break;
                case "w":
                    Work = RunFoward(1, this.speed);
                    Work.Wait();
                    break;
                case "s":
                    Work = RunBackyard(1, this.speed);
                    Work.Wait();
                    break;
                case " ":
                    Work = Shoot(10, 100);
                    Work.Wait();
                    break;
                default:
                    break;

            }
        }
        //Envoie un message au robot pour l'afficher // Send a message to the lcd screen.
        public void SendMessage(string MSG) 
        {
            this.Work = WriteOnBoard(MSG);
            this.Work.Wait();
        }
        //Retourne la densité de la lumière // Return the light level.
        public int GetLightLevel()
        {
            return this.S4;
        }   
        //Retourne si il y a un contact avec la capteur de toucher // Return the touching sensor.
        public int GetTouch()
        {
            return this.S1;
        }
        //Retourne la distance du robot d'un obstacle // Return the distance for the distance's sensor.
        public int GetDistance()
        {
            return this.S3;
        }
        //Retourne la distance parcourrue ; Return the distance done by the motor.
        public int GetDistanceDone()
        {
            return this.B;
        }

           //----------------------------------------------------------//
          //  Tache du robot.    // Robot's Task                        //
         //-----------------------------------------------------------//
        //Connection au robot // Connection to the robots
        private async Task Connect()
        {
            try
            {
                Connected = false;
                EV3.BrickChanged += Output;
                Console.WriteLine("Essaie de connection");
                await EV3.ConnectAsync();
                await EV3.DirectCommand.PlayToneAsync(0x50, 5000, 500);
                EV3.BatchCommand.SetLedPattern(LedPattern.Black);
                EV3.Ports[InputPort.Four].PropertyChanged += this.Input4_Change;
                EV3.Ports[InputPort.Three].PropertyChanged += this.Input3_Change;
                EV3.Ports[InputPort.Two].PropertyChanged += this.Input2_Change;
                EV3.Ports[InputPort.One].PropertyChanged += this.Input1_Change;
                EV3.Ports[InputPort.B].PropertyChanged += this.InputB_Change;
                EV3.Ports[InputPort.A].PropertyChanged += this.InputA_Change;
                EV3.Ports[InputPort.C].PropertyChanged += this.InputC_Change;
                EV3.Ports[InputPort.D].PropertyChanged += this.InputD_Change;
                await EV3.DirectCommand.CleanUIAsync();
                await EV3.DirectCommand.UpdateUIAsync();
                Connected = true;
                Console.WriteLine("Robot Connecté!");

            }
            catch
            {
                Console.WriteLine("Aucune Connection Possible...");
            }
        }
        //Ordre d'afficher un message // Order to show a message on the small lcd screen
        private async Task WriteOnBoard(string MSG)
        {
            Color TextColor;
            TextColor = Color.Foreground;
            EV3.DirectCommand.CleanUIAsync();
            EV3.DirectCommand.DrawTextAsync(TextColor, 10, 50, MSG);
            EV3.DirectCommand.UpdateUIAsync();
            
            Console.WriteLine("Msg Send");
            EV3.DirectCommand.PlaySoundAsync(100, "Object");
        }
        //Ordre de tirer    // Order to shoot a ball
        private async Task Shoot(uint second, int vitesse)
        {
            //On établie la polarité des moteurs!
            EV3.DirectCommand.SetMotorPolarity(OutputPort.D, Polarity.Forward);
            //On démarre les moteurs
            EV3.DirectCommand.TurnMotorAtPowerAsync(OutputPort.D, vitesse);
            EV3.DirectCommand.TurnMotorAtPowerForTimeAsync(OutputPort.D, vitesse, second * 100, false);
        }
        //Ordre d'avancer en ligne droite // Order to go forward
        private async Task RunFoward(uint second, int vitesse)
        {
            //On établie la polarité des moteurs!
            EV3.DirectCommand.SetMotorPolarity(OutputPort.B, Polarity.Forward);
            EV3.DirectCommand.SetMotorPolarity(OutputPort.C, Polarity.Forward);
            //On démarre les moteurs
            EV3.DirectCommand.TurnMotorAtPowerAsync(OutputPort.B, vitesse);
            EV3.DirectCommand.TurnMotorAtPowerForTimeAsync(OutputPort.B, vitesse, second * 100, false);
            EV3.DirectCommand.TurnMotorAtPowerAsync(OutputPort.C, vitesse);
            EV3.DirectCommand.TurnMotorAtPowerForTimeAsync(OutputPort.C, vitesse, second * 100, false);
        }
        //Ordre de reculer en ligne droite // Order to go backward
        private async Task RunBackyard(uint second, int vitesse)
        {
            //On établie la polarité des moteurs!
             EV3.DirectCommand.SetMotorPolarity(OutputPort.B, Polarity.Backward);
             EV3.DirectCommand.SetMotorPolarity(OutputPort.C, Polarity.Backward);
            //On démarre les moteurs
             EV3.DirectCommand.TurnMotorAtPowerAsync(OutputPort.B, vitesse);
             EV3.DirectCommand.TurnMotorAtPowerForTimeAsync(OutputPort.B, vitesse, second * 100, false);
             EV3.DirectCommand.TurnMotorAtPowerAsync(OutputPort.C, vitesse);
             EV3.DirectCommand.TurnMotorAtPowerForTimeAsync(OutputPort.C, vitesse, second * 100, false);
        }
        //Ordre de tourner a gauche // Order to turn left
        private async Task TurnLeft(uint second, int vitesse)
        {
            //On établie la polarité des moteurs!
             EV3.DirectCommand.SetMotorPolarity(OutputPort.B, Polarity.Forward);
             EV3.DirectCommand.SetMotorPolarity(OutputPort.C, Polarity.Backward);
            //On démarre les moteurs
             EV3.DirectCommand.TurnMotorAtPowerAsync(OutputPort.B, vitesse);
             EV3.DirectCommand.TurnMotorAtPowerForTimeAsync(OutputPort.B, vitesse, second * 100, false);
             EV3.DirectCommand.TurnMotorAtPowerAsync(OutputPort.C, vitesse);
             EV3.DirectCommand.TurnMotorAtPowerForTimeAsync(OutputPort.C, vitesse, second * 100, false);
        }
        //Ordre de tourner a droite // Order to turn right
        private async Task TurnRight(uint second, int vitesse)
        {
            //On établie la polarité des moteurs!
             EV3.DirectCommand.SetMotorPolarity(OutputPort.B, Polarity.Backward);
             EV3.DirectCommand.SetMotorPolarity(OutputPort.C, Polarity.Forward);
            //On démarre les moteurs
             EV3.DirectCommand.TurnMotorAtPowerAsync(OutputPort.B, vitesse);
             EV3.DirectCommand.TurnMotorAtPowerForTimeAsync(OutputPort.B, vitesse, second * 100, false);
             EV3.DirectCommand.TurnMotorAtPowerAsync(OutputPort.C, vitesse);
             EV3.DirectCommand.TurnMotorAtPowerForTimeAsync(OutputPort.C, vitesse, second * 100, false);
        }

        //Le Robots communique sont changement d'état // Robot's communication event
        private void Output(object sender, BrickChangedEventArgs e)
        {
            Console.WriteLine(e.ToString());
        }
        
           //----------------------------------------------------------//
          // Les capteurs du robot //Robot's Sensor.                    //
         //-----------------------------------------------------------//
        //La valeur du capteur 1 change // Event: When the sensor 1 change his state.
        private void Input1_Change(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            //Pression
            Console.WriteLine("Niveau de pression : " + (EV3.Ports[InputPort.One].RawValue));
            this.S1 = (EV3.Ports[InputPort.One].RawValue);
        }
        //La valeur du capteur 2 change // Event: When the sensor 2 change his state.
        private void Input2_Change(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            //Console.WriteLine("Capteur 2 Valeur : " + EV3.Ports[InputPort.Two].RawValue);
        }
        //La valeur du capteur 3 change // Event: When the sensor 3 change his state.
        private void Input3_Change(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            //Distance
            Console.WriteLine("Distance : " + EV3.Ports[InputPort.Three].RawValue);
            this.S3 = EV3.Ports[InputPort.Three].RawValue;
        }
        //La valeur du capteur 4 change // Event: When the sensor 4 change his state.
        private void Input4_Change(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Console.WriteLine("Niveau de lumière : " + (EV3.Ports[InputPort.Four].RawValue) + "%");
            this.S4 = (EV3.Ports[InputPort.Four].RawValue);
        }

           //----------------------------------------------------------//
          //  Moteur.                                                  //
         //---------------------------------------------------------//
        //La valeur du capteur A change // Event: When the sensor A change his state.
        private void InputA_Change(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
           //
        }
        //La valeur du capteur B change // Event: When the sensor B change his state.
        private void InputB_Change(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            //Moteur B -- Jambe
            this.B = EV3.Ports[InputPort.B].RawValue / 360;
        }
        //La valeur du capteur C change // Event: When the sensor C change his state.
        private void InputC_Change(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            //Moteur C -- Jambe
            this.C = EV3.Ports[InputPort.C].RawValue / 360;
        }
        //La valeur du capteur D change // Event: When the sensor D change his state.
        private void InputD_Change(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            //Moteur D -- Gun
            this.D = EV3.Ports[InputPort.D].RawValue / 360;
        }

        //La valeur d'un des capteurs change // Event: When any sensor change his state.
        private void SensorChanges(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            //Console.WriteLine("Capteur Pression : " + EV3.Ports[InputPort.B].RawValue);
            //Console.WriteLine("Capteur % : " + EV3.Ports[InputPort.B].PercentValue);
            //Console.WriteLine("Capteur I : " + EV3.Ports[InputPort.B].SIValue / 360);
            //Console.WriteLine(EV3.Ports[InputPort.B].Name);
            //Console.WriteLine("Capteur Pression : " + EV3.Ports[InputPort.One].RawValue);
            //Console.WriteLine("Capteur 2 Valeur : " + EV3.Ports[InputPort.Two].RawValue); // Déplugger
            //Console.WriteLine("Capteur Distance : " + EV3.Ports[InputPort.Three].RawValue + "cm");
            //Console.WriteLine("Capteur Lumière : " + EV3.Ports[InputPort.Four].RawValue + "/32");

        }
    }
}
