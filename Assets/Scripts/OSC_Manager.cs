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

                default:
                break;
            }
            
            //message.values.Add(0);

            osc.Send(message);

            Debug.Log(buttonPressed + " was pressed");

            //send message to Ableton
            


        }

}



/*
    void OnReceiveXYZ(OscMessage message)
    {
        float x = message.GetFloat(0);
        float y = message.GetFloat(1);
        float z = message.GetFloat(2);

        transform.position = new Vector3(x, y, z);
    }

    void OnReceiveX(OscMessage message)
    {
        float x = message.GetFloat(0);

        Vector3 position = transform.position;

        position.x = x;

        transform.position = position;
    }

    void OnReceiveY(OscMessage message)
    {
        float y = message.GetFloat(0);

        Vector3 position = transform.position;

        position.y = y;

        transform.position = position;
    }

    void OnReceiveZ(OscMessage message)
    {
        float z = message.GetFloat(0);

        Vector3 position = transform.position;

        position.z = z;

        transform.position = position;
    }


}
*/