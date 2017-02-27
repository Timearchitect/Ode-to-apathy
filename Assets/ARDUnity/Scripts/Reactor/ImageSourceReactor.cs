using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Ardunity
{
	[AddComponentMenu ("ARDUnity/Reactor/Effect/ImageSourceReactor")]
	[HelpURL ("https://sites.google.com/site/ardunitydoc/references/reactor/audiosourcereactor")]
	[RequireComponent (typeof(Image))]
	public class ImageSourceReactor : ArdunityReactor
	{
		private IWireInput<bool> _digitalInput;
		private IWireInput<Trigger> _triggerInput;
		private IWireInput<float> _analogInput;
		public Image _imageSource;
		const float maxDarkness=0.4f;
		protected override void Awake ()
		{
			base.Awake ();
			print ("yo awake image");

			_imageSource = GetComponent<Image> ();
		}
	
		// Use this for initialization
		void Start ()
		{
			//print ("yo start Image");

			_imageSource = GetComponent<Image> ();

		}

		void OnEnable ()
		{
			if (_analogInput != null) {
				//print ("yo enabled image "+ _imageSource.name);
				_imageSource.color = new Color (0, 0, 0, _analogInput.input);
			}
		}
		
		// Update is called once per frame
		void Update ()
		{
		
		}

		private void OnDigitalInputChanged (bool value)
		{			
			/*if (value)
				_imageSource.Play ();
			else
				_imageSource.Stop ();*/
		}

		private void OnTriggerInputChanged (Trigger value)
		{			
			//if (value.value)
			//	_imageSource.Play ();
		}

		private void OnAnalogInputChanged (float value)
		{			
			print ("yo analogin image"+ _imageSource.name);

			_imageSource.color = new Color(0,0,0,value);
		}

		protected override void AddNode (List<Node> nodes)
		{
			base.AddNode (nodes);
		
			nodes.Add (new Node ("setAlpha", "Set Alpha", typeof(IWireInput<float>), NodeType.WireFrom, "Input<float>"));

		}

		protected override void UpdateNode (Node node)
		{
			//print ("yo update image: "+node.name);

			 if (node.name.Equals ("setAlpha")) {
				node.updated = true;
				//print ("yo inside: ");

				if (node.objectTarget == null && _analogInput == null) {
					print ("yo no Node for targeted image!!! ");
					return;
				}
				if (node.objectTarget != null) {
					
					/*if (node.objectTarget.Equals (_analogInput)) {
						print ("same value of the alpha as arduino LDR");
						return;
					}*/
					/*if (((Image)node.objectTarget).color.a == _analogInput.input) {
						print ("same value of the alpha as arduino LDR");
						return;
					}*/
				}

				if (_analogInput != null)
					_analogInput.OnWireInputChanged -= OnAnalogInputChanged;

				_analogInput = node.objectTarget as IWireInput<float>;

				if (_analogInput != null) {
					if (_imageSource != null) {
						print (_imageSource.name + " changing");
					_imageSource.color= new Color(0,0,0,Mathf.Clamp(1-_analogInput.input,0,maxDarkness));
					}
					/*if (_analogInput.input <= 0.6f) {
						Debug.Log ("DARKNESS!");
					}*/
						//GameObject.FindGameObjectWithTag ("leftEye").GetComponent<Image> ().color = new Color(0,0,0,Mathf.Clamp(1-_analogInput.input,0,maxDarkness));
						//GameObject.FindGameObjectWithTag ("rightEye").GetComponent<Image> ().color = new Color(0,0,0,Mathf.Clamp(1-_analogInput.input,0,maxDarkness));

				//AudioSource[] aS = (AudioSource[])GameObject.FindObjectsOfType (typeof(AudioSource));
				//print ();
						//GameObject.FindGameObjectWithTag("leftEye").GetComponent<Image>().color = new Color (0, 0, 0, _analogInput.input);
						//GameObject.FindGameObjectWithTag ("rightEye").GetComponent<Image>().color = new Color (0, 0, 0, _analogInput.input);

						//print(_analogInput.input + "  A1 VALUE Image : " );

			

					/*print (_analogInput.input + "  A0 VALUE");
					GameObject.FindGameObjectWithTag ("cafe").GetComponent<Image> ().volume = _analogInput.input * .04F;
					AudioSource[] aS = (AudioSource[])GameObject.FindObjectsOfType (typeof(AudioSource));
					if (_analogInput.input <= 0.6f) {
						foreach (AudioSource a in aS) {
							a.GetComponent<AudioSource> ().bypassEffects = false;
						}
						//GameObject.FindGameObjectWithTag ("cafe").GetComponent<AudioSource> ().bypassEffects = false;
						//GameObject.FindGameObjectWithTag ("bgm").GetComponent<AudioSource> ().bypassEffects = false;
					} else {
						foreach (AudioSource a in aS) {
							a.GetComponent<AudioSource> ().bypassEffects = true;
						}
						//GameObject.FindObjectOfType<AudioSource>().GetComponent<AudioSource>().bypassEffects=false;
						//GameObject.FindGameObjectWithTag ("cafe").GetComponent<AudioSource> ().bypassEffects = true;
						//GameObject.FindGameObjectWithTag ("bgm").GetComponent<AudioSource> ().bypassEffects = true;
					}
					_analogInput.OnWireInputChanged += OnAnalogInputChanged;*/
				} else
					node.objectTarget = null;

				return;
			}
                        
			base.UpdateNode (node);
		}
	}
}