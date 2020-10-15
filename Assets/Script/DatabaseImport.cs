using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class DatabaseImport : MonoBehaviour
{
    public GameObject[] IRSpheres;
    public GameObject IRSDistance, LatText, LongText, VitText, AglText, SonicText, AltText, QualityText, SattText;
    public string AngleValue, VitValue, LongValue, LatValue, DistValue, IR1Value, IR2Value, IR3Value, IR4Value, IR5Value, Extractor, SattValue, AltValue;
    public int i, iLength;
    public int ArrayIndex = 0;
    public Material IRSphereRouge;
    public Material IRSphereVert;
    public int fArray, larray;
    public string titeboule;
    public int SphereID;
    public string[] SensorValueArray;

    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        fArray = 0;
        larray = 0;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(GetDbData());
        IEnumerator GetDbData()
        {
            using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/TrackedRobot/GetDbData.php"))
            {
                yield return www.Send();

                if (www.isNetworkError || www.isHttpError)
                {
                    Debug.Log(www.error);
                }
                else
                {
                    Debug.Log(www.downloadHandler.text);
                    Extractor = www.downloadHandler.text;
                    string[] SensorArray = { "Start", "IR1", "IR2", "IR3", "IR4", "IR5", "IRSDIST", "SONIC", "LONGG", "LAT", "ALT", "QUALITY", "SATT", "END" };

                    foreach (string Arr in SensorArray)
                    {
                        int NextArray = 0;
                        if (Arr == "END") { }
                        else
                        {
                            NextArray = (Array.IndexOf(SensorArray, Arr) + 1);
                            int ExtractorFrom = Extractor.IndexOf(Arr) + Arr.Length;
                            int ExtractorTo = Extractor.LastIndexOf(SensorArray[NextArray]);
                            titeboule = Extractor.Substring(ExtractorFrom, ExtractorTo - ExtractorFrom);
                            Debug.Log(titeboule + " " + Arr);
                            if ((Array.IndexOf(SensorArray, Arr) > 0) && (Array.IndexOf(SensorArray, Arr) < 5))
                            {
                                if (titeboule == "1")
                                {//sphere verte
                                    IRSpheres[(Array.IndexOf(SensorArray, Arr))].GetComponent<MeshRenderer>().material = IRSphereVert;
                                }
                                else
                                {//sphere rouge
                                    IRSpheres[(Array.IndexOf(SensorArray, Arr))].GetComponent<MeshRenderer>().material = IRSphereRouge;
                                }
                            }
                            
                            int ExtractLONGFrom = Extractor.IndexOf("LONGG") + "LONGG".Length;
                            int ExtractLONGTo = Extractor.LastIndexOf("LAT");
                            LongValue = Extractor.Substring(ExtractLONGFrom, ExtractLONGTo - ExtractLONGFrom);
                            TextMesh textObject3 = GameObject.Find("LongText").GetComponent<TextMesh>();
                            textObject3.text = "Longitude: " + LongValue;

                            int ExtractLATFrom = Extractor.IndexOf("LAT") + "LAT".Length;
                            int ExtractLATTo = Extractor.LastIndexOf("ALT");
                            LatValue = Extractor.Substring(ExtractLATFrom, ExtractLATTo - ExtractLATFrom);
                            TextMesh textObject4 = GameObject.Find("LatText").GetComponent<TextMesh>();
                            textObject4.text = "Latitude: " + LatValue;

                            int ExtractAltFrom = Extractor.IndexOf("ALT") + "ALT".Length;
                            int ExtractAltTo = Extractor.LastIndexOf("SATT");
                            AltValue = Extractor.Substring(ExtractAltFrom, ExtractAltTo - ExtractAltFrom);
                            TextMesh textObject1 = GameObject.Find("AltText").GetComponent<TextMesh>();
                            textObject1.text = "Altitude: " + AltValue;

                            int ExtractSattFrom = Extractor.IndexOf("SATT") + "SATT".Length;
                            int ExtractSattTo = Extractor.LastIndexOf("END");
                            SattValue = Extractor.Substring(ExtractSattFrom, ExtractSattTo - ExtractSattFrom);
                            TextMesh textObject2 = GameObject.Find("SattText").GetComponent<TextMesh>();
                            textObject2.text = SattValue;

                            int ExtractIRSDISTFrom = Extractor.IndexOf("IRSDIST") + "IRSDIST".Length;
                            int ExtractIRSDISTTo = Extractor.LastIndexOf("LONGG");
                            DistValue = Extractor.Substring(ExtractIRSDISTFrom, ExtractIRSDISTTo - ExtractIRSDISTFrom);
                            TextMesh textObject5 = GameObject.Find("IRSDIST").GetComponent<TextMesh>();
                            textObject5.text = "Distance: ~" + DistValue + "cm";

                            /*
                                TextMesh textObject1 = GameObject.Find("IRSDistance").GetComponent<TextMesh>();
                                textObject1.text = "Distance: " + SensorValueArray[7];
                                TextMesh textObject3 = GameObject.Find("LongText").GetComponent<TextMesh>();
                                textObject3.text = "Longitude: " + SensorValueArray[9];
                                TextMesh textObject4 = GameObject.Find("LatText").GetComponent<TextMesh>();
                                textObject4.text = "Latitude: " + SensorValueArray[10];
                                TextMesh textObject5 = GameObject.Find("AltText").GetComponent<TextMesh>();
                                textObject5.text = "Altitude: " + SensorValueArray[11];
                                TextMesh textObject8 = GameObject.Find("QualityText").GetComponent<TextMesh>();
                                textObject8.text = "Quality: " + SensorValueArray[14];
                                TextMesh textObject9 = GameObject.Find("SattText").GetComponent<TextMesh>();
                                textObject9.text = SensorValueArray[15];
                            */
                        }
                    }
                }
            }
        }
    }
}