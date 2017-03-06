using UnityEngine;
using System.Collections.Generic;


namespace Ardunity
{
	[AddComponentMenu ("ARDUnity/Reactor/Effect/AudioSourceReactor")]
	[HelpURL ("https://sites.google.com/site/ardunitydoc/references/reactor/audiosourcereactor")]
	[RequireComponent (typeof(AudioSource))]


	public class AudioSourceReactor : ArdunityReactor// , MonoBehaviour 
	{
		private IWireInput<bool> _digitalInput;
		private IWireInput<Trigger> _triggerInput;
		private IWireInput<float> _analogInput;
		private AudioSource _audioSource;
		private AudioSource[] aS;
		private AudioSource bgmL , bgmR;
		public bool paning;

		protected override void Awake ()
		{
			base.Awake ();
			_audioSource = GetComponent<AudioSource> ();
		}
	
		// Use this for initialization
		void Start ()
		{

		}

		void OnEnable ()
		{
			if (_analogInput != null)
				_audioSource.volume = _analogInput.input;
		}
		
		// Update is called once per frame
		void Update ()
		{
		
		}

		private void OnDigitalInputChanged (bool value)
		{			
			if (value)
				_audioSource.Play ();
			else
				_audioSource.Stop ();
		}

		private void OnTriggerInputChanged (Trigger value)
		{			
			if (value.value)
				_audioSource.Play ();
		}

		private void OnAnalogInputChanged (float value)
		{			
			_audioSource.volume = value;
		}

		protected override void AddNode (List<Node> nodes)
		{
			base.AddNode (nodes);
			nodes.Add (new Node ("play", "Play", typeof(IWireInput<bool>), NodeType.WireFrom, "Input<bool>"));
			nodes.Add (new Node ("playOnly", "Play Only", typeof(IWireInput<Trigger>), NodeType.WireFrom, "Input<Trigger>"));
			nodes.Add (new Node ("setVolume", "Set Volume", typeof(IWireInput<float>), NodeType.WireFrom, "Input<float>"));
			nodes.Add (new Node ("setBypassFilterR", "Set Bypass Right", typeof(IWireInput<float>), NodeType.WireFrom, "Input<bool>"));
			nodes.Add (new Node ("setBypassFilterL", "Set Bypass Left", typeof(IWireInput<float>), NodeType.WireFrom, "Input<bool>"));

		}

		protected override void UpdateNode (Node node)
		{
			if (node.name.Equals ("play")) {
				node.updated = true;
				if (node.objectTarget == null && _digitalInput == null)
					return;
                
				if (node.objectTarget != null) {
					if (node.objectTarget.Equals (_digitalInput))
						return;
				}
                
				if (_digitalInput != null)
					_digitalInput.OnWireInputChanged -= OnDigitalInputChanged;
                
				_digitalInput = node.objectTarget as IWireInput<bool>;
				if (_digitalInput != null)
					_digitalInput.OnWireInputChanged += OnDigitalInputChanged;
				else
					node.objectTarget = null;
				return;
			} else if (node.name.Equals ("playOnly")) {
				node.updated = true;
				if (node.objectTarget == null && _triggerInput == null)
					return;
                
				if (node.objectTarget != null) {
					if (node.objectTarget.Equals (_triggerInput))
						return;
				}
                
				if (_triggerInput != null)
					_triggerInput.OnWireInputChanged -= OnTriggerInputChanged;
                
				_triggerInput = node.objectTarget as IWireInput<Trigger>;
				if (_triggerInput != null)
					_triggerInput.OnWireInputChanged += OnTriggerInputChanged;
				else
					node.objectTarget = null;
                
				return;
			} else if (node.name.Equals ("setVolume")) {
				node.updated = true;
				if (node.objectTarget == null && _analogInput == null)
					return;
                
				if (node.objectTarget != null) {
					if (node.objectTarget.Equals (_analogInput))
						return;
				}
                
				if (_analogInput != null)
					_analogInput.OnWireInputChanged -= OnAnalogInputChanged;
                
				_analogInput = node.objectTarget as IWireInput<float>;
				if (_analogInput != null)
					_analogInput.OnWireInputChanged += OnAnalogInputChanged;
				else
					node.objectTarget = null;
				return;

			} else if (node.name.Equals ("setBypassFilterR")) {
				node.updated = true;
				if (node.objectTarget == null && _analogInput == null)
					return;
				if (node.objectTarget != null) {
					if (node.objectTarget.Equals (_analogInput))
						return;
				}

				if (_analogInput != null)
					_analogInput.OnWireInputChanged -= OnAnalogInputChanged;
				
				_analogInput = node.objectTarget as IWireInput<float>;
				if (_analogInput != null) {
					if (aS == null || bgmR == null) {
						aS = (AudioSource[])GameObject.FindObjectsOfType (typeof(AudioSource));
						//bgm = GameObject.FindGameObjectWithTag ("cafe").GetComponent<AudioSource> ();
						bgmR = GameObject.Find ("Cafe bgm Right").GetComponent<AudioSource> ();
					}
					//print (_analogInput.input + "  A0 VALUE audio");
					bgmR.volume = _analogInput.input * .04F;
					//AudioSource[] aS = (AudioSource[])GameObject.FindObjectsOfType (typeof(AudioSource));
					if (_analogInput.input <= 0.6f) {
						foreach (AudioSource a in aS) {
							a.GetComponent<AudioSource> ().bypassEffects = false;
						}
					} else {
						foreach (AudioSource a in aS) {
							a.GetComponent<AudioSource> ().bypassEffects = true;
						}
					}
					_analogInput.OnWireInputChanged += OnAnalogInputChanged;
				} else
					node.objectTarget = null;

				return;
			} else if (node.name.Equals ("setBypassFilterL")) {
				node.updated = true;
				if (node.objectTarget == null && _analogInput == null)
					return;
				if (node.objectTarget != null) {
					if (node.objectTarget.Equals (_analogInput))
						return;
				}

				if (_analogInput != null)
					_analogInput.OnWireInputChanged -= OnAnalogInputChanged;
				_analogInput = node.objectTarget as IWireInput<float>;

				if (_analogInput != null) {
					if (aS == null || bgmL == null) {
						aS = (AudioSource[])GameObject.FindObjectsOfType (typeof(AudioSource));
						//bgm = GameObject.FindGameObjectWithTag ("cafe").GetComponent<AudioSource> ();
						//bgmL = GameObject.FindGameObjectWithTag ("cafe").GetComponent<AudioSource> ();
						bgmL = GameObject.Find ("Cafe bgm Left").GetComponent<AudioSource> ();
					}
					//print (_analogInput.input + "  A0 VALUE audio");
					bgmL.volume = _analogInput.input * .04F;

					//AudioSource[] aS = (AudioSource[])GameObject.FindObjectsOfType (typeof(AudioSource));
					if (_analogInput.input <= 0.6f) {
						foreach (AudioSource a in aS) {
							a.GetComponent<AudioSource> ().bypassEffects = false;
						}
					} else {
						foreach (AudioSource a in aS) {
							a.GetComponent<AudioSource> ().bypassEffects = true;
						}
					}
					_analogInput.OnWireInputChanged += OnAnalogInputChanged;
				} else
					node.objectTarget = null;

				return;
			}
                        
			base.UpdateNode (node);
		}
	}
}