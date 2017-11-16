using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mynamajeff : MonoBehaviour {

    public PlayerShoot playerPostition;

	void Start () {
        StartCoroutine(Doquery());
	}

    IEnumerator Doquery()
    {
        WWW request = new WWW("http://22355.hosts.ma-cloud.nl/bewijzenmap/p2.1/GPR/moan.php?t_x=" + playerPostition.targetX + "&t_y=" + playerPostition.targetY + "&t_z=" + playerPostition.targetZ + "&p_id=3");
        yield return request;
    }
	
}
