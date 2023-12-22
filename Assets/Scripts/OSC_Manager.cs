using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OSC_Manager : MonoBehaviour
{

    public OSC osc;

    [SerializeField] 
    private Button ButtonL1S;

    [SerializeField] 
    private Button ButtonL1R;

    [SerializeField] 
    private Button ButtonL1P;

    [SerializeField] 
    private Button ButtonL1O;

    [SerializeField]
    private Scrollbar ScrollbarL1V;


    [SerializeField] 
    private Button ButtonL2S;

    [SerializeField] 
    private Button ButtonL2R;

    [SerializeField] 
    private Button ButtonL2P;

    [SerializeField] 
    private Button ButtonL2O;

    [SerializeField]
    private Scrollbar ScrollbarL2V;

    [SerializeField]
    private Scrollbar tempoSelector; //tempo selector sends 60-180

    [SerializeField]
    private Button ButtonMetronome; //metronome toggle sends 0

    //need to initialize empty variables to be sent as messages(?)
    /*private object stop;
    private object play;
    private object record;
    private object overdub;
    private object volume*/

    // Use this for initialization
    void Start()
    {

        //ButtonL1S.onClick.AddListener(OnButtonPressed);
        
        ButtonL1S.onClick.AddListener(() => OnButtonPressed(ButtonL1S));
        ButtonL1R.onClick.AddListener(() => OnButtonPressed(ButtonL1R));
        ButtonL1P.onClick.AddListener(() => OnButtonPressed(ButtonL1P));
        ButtonL1O.onClick.AddListener(() => OnButtonPressed(ButtonL1O));
        ScrollbarL1V.onValueChanged.AddListener((val) => OnValueChanged(ScrollbarL1V, val));

        ButtonL2S.onClick.AddListener(() => OnButtonPressed(ButtonL2S));
        ButtonL2R.onClick.AddListener(() => OnButtonPressed(ButtonL2R));
        ButtonL2P.onClick.AddListener(() => OnButtonPressed(ButtonL2P));
        ButtonL2O.onClick.AddListener(() => OnButtonPressed(ButtonL2O));
        ScrollbarL2V.onValueChanged.AddListener((val) => OnValueChanged(ScrollbarL2V, val));

        ButtonMetronome.onClick.AddListener(() => OnButtonPressed(ButtonMetronome));
        tempoSelector.onValueChanged.AddListener((val) => OnValueChanged(tempoSelector, val));
        //osc.SetAddressHandler("/looper1", OnButtonPressed);

       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnButtonPressed(Button buttonPressed) //OscMessage message)
        {

            OscMessage message = new OscMessage();

            //message.address = "/looper1";
            Debug.Log(buttonPressed.name);
            //underscores are necessary for distinguishing buttons in scene from script references
            //osc.add.values seem to be of a type that can take strings
            switch(buttonPressed.name)
            {
                case "Button_L1S":
                message.address = "/looper1";
                message.values.Add(0);
                //message.values.Add(stop);
                //message.values.Add(1);
                Debug.Log("ButtonL1S!!!");
                break;

                case "Button_L1R":
                message.address = "/looper1";
                message.values.Add(1);
                //message.values.Add(record);
                break;

                case "Button_L1P":
                message.address = "/looper1";
                message.values.Add(2);
                //message.values.Add(play);
                break;

                case "Button_L1O":
                message.address = "/looper1";
                message.values.Add(3);
                //message.values.Add(overdub);
                break;

                case "Button_L2S":
                message.address = "/looper2";
                message.values.Add(0);
                //message.values.Add(stop);
                //message.values.Add(1);
                Debug.Log("ButtonL1S!!!");
                break;

                case "Button_L2R":
                message.address = "/looper2";
                message.values.Add(1);
                //message.values.Add(record);
                break;

                case "Button_L2P":
                message.address = "/looper2";
                message.values.Add(2);
                //message.values.Add(play);
                break;

                case "Button_L2O":
                message.address = "/looper2";
                message.values.Add(3);
                //message.values.Add(overdub);
                break;

                case "ButtonMetronome":
                message.address = "/settings";
                message.values.Add(0);
                Debug.Log("METRONOME BUTTON PRESSED");
                break;

                default:
                break;
            }
            
            //message.values.Add(0);

            osc.Send(message);

            Debug.Log(buttonPressed + " was pressed");

            //send message to Ableton
            


        }




    public void OnValueChanged(Scrollbar scrollbar, float val) //OscMessage message)
        {

            OscMessage message = new OscMessage();

            //message.address = "/looper1";
            Debug.Log(scrollbar.name);
            //underscores are necessary for distinguishing buttons in scene from script references
            //osc.add.values seem to be of a type that can take strings
            switch(scrollbar.name)
            {
                case "Scrollbar_L1V":
                message.address = "/looper1";
                message.values.Add(val); //make sure to clamp from 0-.85(?), and this way 0 will also stop the track?
                Debug.Log("Scrollbar L1V was " + val);
                break;
    
                case "Scrollbar_L2V":
                message.address = "/looper2";
                message.values.Add(val);
                Debug.Log("Scrollbar L2V was " + val);
                break;
        /*
                case "Scrollbar_L3V":
                message.address = "/looper3";
                message.values.Add(val);
                Debug.Log("Scrollbar L3V was " + val);
                break;

                case "Scrollbar_L4V":
                message.address = "/looper4";
                message.values.Add(val);
                Debug.Log("Scrollbar L4V was " + val);
                break;
    */

                case "Tempo Selector":
                message.address = "/settings";
                message.values.Add(Mathf.RoundToInt(val * 120 + 60));
                Debug.Log("Tempo Selector was " + (val * 120 + 60));
                break;
                default:
                break;
            }

            osc.Send(message);

            //send message to Ableton
            


        }

}

