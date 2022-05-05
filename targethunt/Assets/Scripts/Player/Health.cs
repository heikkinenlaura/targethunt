using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    // T‰lle scriptille pit‰‰ tehd‰ gameobject hierarkiaan ja raahata skripti siihen.
    // Pidet‰‰n syd‰met taulukossa. **N‰m‰ pit‰‰ raahata Unityn Inspectorissa oikeisiin paikkoihin.
    // Eli kasvatat inspectorissa hearts taulun kokoa kolmeen ja raahaat syd‰met oikeille paikoilleen.**
    public GameObject[] hearts;
    public GameObject panel;

    public float health;

    // Tehd‰‰n t‰st‰ scriptist‰ Singleton, eli muista scripteist‰ voi t‰m‰n scriptin funktioihin
    // p‰‰st‰ k‰siksi esim: GameControlScript.Instance.TakeDamage(0.5f);
    public static Health Instance;

    // Alustetaan Singleton Awake -funktiossa
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        health = 3f;
        foreach (GameObject heart in hearts)
        {
            heart.SetActive(true);
        }
    }

    // Tehd‰‰n t‰nne yleinen funktio, johon laitetaan kaikki tapaukset, jos pelaaja ottaa vahinkoa.
    public void TakeDamage(float damage)
    {
        // V‰hennet‰‰n eka healthista damagen m‰‰r‰.
        health -= damage;
        // K‰yd‰‰n for -loopilla Hearts -taulu l‰pi. Voidaan p‰‰tell‰ j‰ljell‰ olevan healthin m‰‰r‰st‰
        // se, ett‰ pit‰‰kˆ kyseisen syd‰men n‰ytt‰‰ animaatio.
        // Muista, ett‰ jos sinulla on kolme syd‰nt‰, niin ensimm‰inen syd‰n on hearts taulukossa
        // indeksiss‰ 0, toinen indeksiss‰ 1 ja kolmas indeksiss‰ 2.
        for (int i = 0; i < hearts.Length; i++)
        {
            // Jos j‰ljell‰ oleva healthin m‰‰r‰ on pienempi kuin syd‰men indeksi taulussa
            // n‰ytet‰‰n animaatio. Mathf.Ceil pyˆrist‰‰ healthin ylˆsp‰in kokonaislukuun
            // esim. Jos health on 2.5, niin se pyˆristet‰‰n lukuun 3
            // Muista ottaa syd‰mien animaattorista "Can transition to self" checkbox pois p‰‰lt‰.
            if (Mathf.Ceil(health) < i + 1)
            {
                hearts[i].GetComponent<Animator>().SetTrigger("takedmg");
            }
        }
        if (health <= 0f)
        {
            //SceneManager.LoadScene(3);
            Time.timeScale = 0;
            panel.gameObject.SetActive(true);
        }
    }
}
