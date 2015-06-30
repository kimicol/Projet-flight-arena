using UnityEngine;
using System.Collections;

public class multi_input : controlplayer 
{
    Vector3 last_pos;
    Quaternion last_rot;
    float distance = 0.01f;
    float angle = 0.01f;

    private KeyCode[] all_keys;
    private string[] name_keys;
    public KeyCode[] used_keys;

    void Awake()
    {
        //enabled = networkView.isMine;
        rigidbody.isKinematic = !networkView.isMine;

        mode_jeu = PlayerPrefs.GetInt("mode_jeu", mode_jeu);
        if (PlayerPrefs.HasKey("mode_jeu"))
        {
            mode_jeu = PlayerPrefs.GetInt("mode_jeu", mode_jeu);
        }
        else
        {
            PlayerPrefs.SetInt("mode_jeu", mode_jeu);
        }
    }

	// Use this for initialization
	void Start ()
    {
        last_pos = transform.position;
        last_rot = transform.rotation;

        #region keys
        all_keys = new KeyCode[63];
        all_keys[0] = KeyCode.Ampersand;
        all_keys[1] = KeyCode.A;
        all_keys[2] = KeyCode.AltGr;
        all_keys[3] = KeyCode.Alpha0;
        all_keys[4] = KeyCode.Alpha1;
        all_keys[5] = KeyCode.Alpha2;
        all_keys[6] = KeyCode.Alpha3;
        all_keys[7] = KeyCode.Alpha4;
        all_keys[8] = KeyCode.Alpha5;
        all_keys[9] = KeyCode.Alpha6;
        all_keys[10] = KeyCode.Alpha7;
        all_keys[11] = KeyCode.Alpha8;
        all_keys[12] = KeyCode.Alpha9;
        all_keys[13] = KeyCode.B;
        all_keys[14] = KeyCode.C;
        all_keys[15] = KeyCode.D;
        all_keys[16] = KeyCode.Delete;
        all_keys[17] = KeyCode.DownArrow;
        all_keys[18] = KeyCode.E;
        all_keys[19] = KeyCode.F;
        all_keys[20] = KeyCode.G;
        all_keys[21] = KeyCode.H;
        all_keys[22] = KeyCode.I;
        all_keys[23] = KeyCode.J;
        all_keys[24] = KeyCode.K;
        all_keys[25] = KeyCode.Keypad0;
        all_keys[26] = KeyCode.Keypad1;
        all_keys[27] = KeyCode.Keypad2;
        all_keys[28] = KeyCode.Keypad3;
        all_keys[29] = KeyCode.Keypad4;
        all_keys[30] = KeyCode.Keypad5;
        all_keys[31] = KeyCode.Keypad6;
        all_keys[32] = KeyCode.Keypad7;
        all_keys[33] = KeyCode.Keypad8;
        all_keys[34] = KeyCode.Keypad9;
        all_keys[35] = KeyCode.KeypadEnter;
        all_keys[36] = KeyCode.L;
        all_keys[37] = KeyCode.LeftAlt;
        all_keys[38] = KeyCode.LeftArrow;
        all_keys[39] = KeyCode.LeftControl;
        all_keys[40] = KeyCode.LeftShift;
        all_keys[41] = KeyCode.M;
        all_keys[42] = KeyCode.N;
        all_keys[43] = KeyCode.O;
        all_keys[44] = KeyCode.P;
        all_keys[45] = KeyCode.Q;
        all_keys[46] = KeyCode.R;
        all_keys[47] = KeyCode.Return;
        all_keys[48] = KeyCode.RightAlt;
        all_keys[49] = KeyCode.RightArrow;
        all_keys[50] = KeyCode.RightControl;
        all_keys[51] = KeyCode.RightShift;
        all_keys[52] = KeyCode.S;
        all_keys[53] = KeyCode.Space;
        all_keys[54] = KeyCode.T;
        all_keys[55] = KeyCode.Tab;
        all_keys[56] = KeyCode.U;
        all_keys[57] = KeyCode.UpArrow;
        all_keys[58] = KeyCode.V;
        all_keys[59] = KeyCode.W;
        all_keys[60] = KeyCode.X;
        all_keys[61] = KeyCode.Y;
        all_keys[62] = KeyCode.Z;
        #endregion

        name_keys = new string[8];
        used_keys = new KeyCode[8];

        #region name_keys
        int i = 0;
        name_keys[i * 8] = PlayerPrefs.GetString("avancer" + i, name_keys[8 * i]);
        if (PlayerPrefs.HasKey("avancer" + i))
            name_keys[i * 8] = PlayerPrefs.GetString("avancer" + i, name_keys[8 * i]);
        else
            PlayerPrefs.SetString("avancer" + i, name_keys[8 * i]);

        name_keys[i * 8 + 1] = PlayerPrefs.GetString("rothaut" + i, name_keys[8 * i + 1]);
        if (PlayerPrefs.HasKey("rothaut" + i))
            name_keys[i * 8 + 1] = PlayerPrefs.GetString("rothaut" + i, name_keys[8 * i + 1]);
        else
            PlayerPrefs.SetString("rothaut" + i, name_keys[8 * i + 1]);

        name_keys[i * 8 + 2] = PlayerPrefs.GetString("rotbas" + i, name_keys[8 * i + 2]);
        if (PlayerPrefs.HasKey("rotbas" + i))
            name_keys[i * 8 + 2] = PlayerPrefs.GetString("rotbas" + i, name_keys[8 * i + 2]);
        else
            PlayerPrefs.SetString("rotbas" + i, name_keys[8 * i + 2]);

        name_keys[i * 8 + 3] = PlayerPrefs.GetString("pivgauche" + i, name_keys[8 * i + 3]);
        if (PlayerPrefs.HasKey("pivgauche" + i))
            name_keys[i * 8 + 3] = PlayerPrefs.GetString("pivgauche" + i, name_keys[8 * i + 3]);
        else
            PlayerPrefs.SetString("pivgauche" + i, name_keys[8 * i + 3]);

        name_keys[i * 8 + 4] = PlayerPrefs.GetString("pivdroite" + i, name_keys[8 * i + 4]);
        if (PlayerPrefs.HasKey("pivdroite" + i))
            name_keys[i * 8 + 4] = PlayerPrefs.GetString("pivdroite" + i, name_keys[8 * i + 4]);
        else
            PlayerPrefs.SetString("pivdroite" + i, name_keys[8 * i + 4]);

        name_keys[i * 8 + 5] = PlayerPrefs.GetString("rotgauche" + i, name_keys[8 * i + 5]);
        if (PlayerPrefs.HasKey("rotgauche" + i))
            name_keys[i * 8 + 5] = PlayerPrefs.GetString("rotgauche" + i, name_keys[8 * i + 5]);
        else
            PlayerPrefs.SetString("rotgauche" + i, name_keys[8 * i + 5]);

        name_keys[i * 8 + 6] = PlayerPrefs.GetString("rotdroite" + i, name_keys[8 * i + 6]);
        if (PlayerPrefs.HasKey("rotdroite" + i))
            name_keys[i * 8 + 6] = PlayerPrefs.GetString("rotdroite" + i, name_keys[8 * i + 6]);
        else
            PlayerPrefs.SetString("rotdroite" + i, name_keys[8 * i + 6]);

        name_keys[i * 8 + 7] = PlayerPrefs.GetString("feu" + i, name_keys[8 * i + 7]);
        if (PlayerPrefs.HasKey("feu" + i))
            name_keys[i * 8 + 7] = PlayerPrefs.GetString("feu" + i, name_keys[8 * i + 7]);
        else
            PlayerPrefs.SetString("feu" + i, name_keys[8 * i + 7]);
        #endregion

        for (int j = 0; j < used_keys.Length; j++)
        {
            int k = 0;

            while (k < all_keys.Length && all_keys[k].ToString() != name_keys[j])
                k++;

            if (k < all_keys.Length)
                used_keys[j] = all_keys[k];
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (networkView.isMine)
        {
            #region name_keys
            int i = 0;
            name_keys[i * 8] = PlayerPrefs.GetString("avancer" + i, name_keys[8 * i]);
            if (PlayerPrefs.HasKey("avancer" + i))
                name_keys[i * 8] = PlayerPrefs.GetString("avancer" + i, name_keys[8 * i]);
            else
                PlayerPrefs.SetString("avancer" + i, name_keys[8 * i]);

            name_keys[i * 8 + 1] = PlayerPrefs.GetString("rothaut" + i, name_keys[8 * i + 1]);
            if (PlayerPrefs.HasKey("rothaut" + i))
                name_keys[i * 8 + 1] = PlayerPrefs.GetString("rothaut" + i, name_keys[8 * i + 1]);
            else
                PlayerPrefs.SetString("rothaut" + i, name_keys[8 * i + 1]);

            name_keys[i * 8 + 2] = PlayerPrefs.GetString("rotbas" + i, name_keys[8 * i + 2]);
            if (PlayerPrefs.HasKey("rotbas" + i))
                name_keys[i * 8 + 2] = PlayerPrefs.GetString("rotbas" + i, name_keys[8 * i + 2]);
            else
                PlayerPrefs.SetString("rotbas" + i, name_keys[8 * i + 2]);

            name_keys[i * 8 + 3] = PlayerPrefs.GetString("pivgauche" + i, name_keys[8 * i + 3]);
            if (PlayerPrefs.HasKey("pivgauche" + i))
                name_keys[i * 8 + 3] = PlayerPrefs.GetString("pivgauche" + i, name_keys[8 * i + 3]);
            else
                PlayerPrefs.SetString("pivgauche" + i, name_keys[8 * i + 3]);

            name_keys[i * 8 + 4] = PlayerPrefs.GetString("pivdroite" + i, name_keys[8 * i + 4]);
            if (PlayerPrefs.HasKey("pivdroite" + i))
                name_keys[i * 8 + 4] = PlayerPrefs.GetString("pivdroite" + i, name_keys[8 * i + 4]);
            else
                PlayerPrefs.SetString("pivdroite" + i, name_keys[8 * i + 4]);

            name_keys[i * 8 + 5] = PlayerPrefs.GetString("rotgauche" + i, name_keys[8 * i + 5]);
            if (PlayerPrefs.HasKey("rotgauche" + i))
                name_keys[i * 8 + 5] = PlayerPrefs.GetString("rotgauche" + i, name_keys[8 * i + 5]);
            else
                PlayerPrefs.SetString("rotgauche" + i, name_keys[8 * i + 5]);

            name_keys[i * 8 + 6] = PlayerPrefs.GetString("rotdroite" + i, name_keys[8 * i + 6]);
            if (PlayerPrefs.HasKey("rotdroite" + i))
                name_keys[i * 8 + 6] = PlayerPrefs.GetString("rotdroite" + i, name_keys[8 * i + 6]);
            else
                PlayerPrefs.SetString("rotdroite" + i, name_keys[8 * i + 6]);

            name_keys[i * 8 + 7] = PlayerPrefs.GetString("feu" + i, name_keys[8 * i + 7]);
            if (PlayerPrefs.HasKey("feu" + i))
                name_keys[i * 8 + 7] = PlayerPrefs.GetString("feu" + i, name_keys[8 * i + 7]);
            else
                PlayerPrefs.SetString("feu" + i, name_keys[8 * i + 7]);
            #endregion

            for (int j = 0; j < used_keys.Length; j++)
            {
                int k = 0;

                while (k < all_keys.Length && all_keys[k].ToString() != name_keys[j])
                    k++;

                if (k < all_keys.Length)
                    used_keys[j] = all_keys[k];
            }

            av = Input.GetKey(used_keys[0]);
            RH = Input.GetKey(used_keys[1]);
            RB = Input.GetKey(used_keys[2]);
            PG = Input.GetKey(used_keys[3]);
            PD = Input.GetKey(used_keys[4]);
            RG = Input.GetKey(used_keys[5]);
            RD = Input.GetKey(used_keys[6]);
            fire = Input.GetKey(used_keys[7]);

            deplacements();

            if (Vector3.Distance(last_pos, transform.position) > distance)
            {
                last_pos = transform.position;
                networkView.RPC("SetPos", RPCMode.Others, transform.position);
            }

            if (Quaternion.Angle(last_rot, transform.rotation) > angle)
            {
                last_rot = transform.rotation;
                networkView.RPC("SetRot", RPCMode.Others, transform.rotation);
            }
        }
	}

    void OnApplicationQuit()
    {
        Network.Destroy(this.gameObject);
        Network.Disconnect();
    }

    [RPC]
    void SetPos(Vector3 newPos)
    {
        transform.position = newPos;
    }

    [RPC]
    void SetRot(Quaternion newRot)
    {
        transform.rotation = newRot;
    }

    void OnSerializeNetworkView(BitStream flux, NetworkMessageInfo info)
    {
        if (flux.isWriting)
        {
            Vector3 pos = transform.position;
            flux.Serialize(ref pos);
        }
        else
        {
            Vector3 pos = Vector3.zero;
            flux.Serialize(ref pos); //"Decode" it and receive it
            transform.position = pos;
        }
    }
}
