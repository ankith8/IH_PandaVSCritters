using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

//namespace UnityStandardAssets.Characters.ThirdPerson
//{
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class ThirdPersonUserControl : MonoBehaviour
    {
        private ThirdPersonCharacter m_Character; // A reference to the ThirdPersonCharacter on the object
		private PlayerInteraction m_Interaction;
        private Transform m_Cam;                  // A reference to the main camera in the scenes transform
        private Vector3 m_CamForward;             // The current forward direction of the camera
        private Vector3 m_Move;

		private bool m_PlaceBomb;
		private bool m_punch;
       
        private void Start()
        {
            // get the transform of the main camera
            if (Camera.main != null)
            {
                m_Cam = Camera.main.transform;
            }
            else
            {
                Debug.LogWarning(
                    "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.");
                // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
            }

            // get the third person character ( this should never be null due to require component )
            m_Character = GetComponent<ThirdPersonCharacter>();
			m_Interaction = GetComponent<PlayerInteraction>();
        }


        private void Update()
        {
//			if (!m_punch)
//            {
//				m_punch = CrossPlatformInputManager.GetButtonDown("Kick");
//            }

			if (!m_PlaceBomb)
			{
				m_PlaceBomb = CrossPlatformInputManager.GetButtonDown("PlaceBomb");
			}
        }


        // Fixed update is called in sync with physics
        private void FixedUpdate()
        {
            // read inputs
            float h = CrossPlatformInputManager.GetAxisRaw("Horizontal");
			float v = CrossPlatformInputManager.GetAxisRaw("Vertical");

            // calculate move direction to pass to character
            if (m_Cam != null)
            {
                // calculate camera relative direction to move:
                m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
				m_Move = (int)v*m_CamForward + (int)h*m_Cam.right;
            }
            else
            {
                // we use world-relative directions in the case of no main camera
				m_Move = (int)v*Vector3.forward + (int)h*Vector3.right;
            }

            // pass all parameters to the character control script
            m_Character.Move(m_Move, m_PlaceBomb, m_punch);
			m_punch = false;
			m_PlaceBomb = false;
        }
    }
//}
