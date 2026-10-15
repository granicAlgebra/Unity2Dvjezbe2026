using UnityEngine;

public class KPS : MonoBehaviour
{
    // 1 = Kamen - input "A"
    // 2 = Skare - input "S"
    // 3 = Papir - input "D"

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            KPSResolve(1);
        else if (Input.GetKeyDown(KeyCode.S))
            KPSResolve(2);
        else if (Input.GetKeyDown(KeyCode.D))
            KPSResolve(3);
    }

    private void KPSResolve(int playerInput)
    {
        int pcInput = GetPcInput();

        // player win
        if (playerInput == 1 && pcInput == 2 || playerInput == 2 && pcInput == 3 || playerInput == 3 && pcInput == 1)
            Debug.Log($"Player pick {playerInput}, pc pick {pcInput}, player win!");

        // pc win
        else if (playerInput == 1 && pcInput == 3 || playerInput == 2 && pcInput == 1 || pcInput == 3 && pcInput == 2)
            Debug.Log($"Player pick {playerInput}, pc pick {pcInput}, pc win!");
    }

    private int GetPcInput()
    {
        return Random.Range(1, 4);
    }
}
