using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Animator animator;
    float velocity = 0f;
    public float acceleration;
    public float deceleration;
    int velocityHash;

    private void Start() {
        animator = GetComponent<Animator>();
        velocityHash = Animator.StringToHash("Velocity");
    }

    private void Update() {
        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool runPressed = Input.GetKey(KeyCode.LeftShift);

        if (forwardPressed && velocity < 1f) {
            velocity += Time.deltaTime * acceleration;
        }

        if (!forwardPressed && velocity > 0f) {
            velocity -= Time.deltaTime * deceleration;
        }

        animator.SetFloat(velocityHash, velocity);
        velocity = Mathf.Clamp(velocity, 0f, 1f);
    }

}
