using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mynamajeff : MonoBehaviour {


	void Start () {
        StartCoroutine(Doquery());
	}

    IEnumerator Doquery()
    {
        WWW request = new WWW("http://22355.hosts.ma-cloud.nl/bewijzenmap/p2.1/GPR/moan.php?t_x=20&t_y=30&t_z=101&p_id=3");
        yield return request;
    }
	
}
