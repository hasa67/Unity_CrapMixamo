using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blend2D : MonoBehaviour {

    Animator animator;
    float velocityZ = 0f;
    float velocityX = 0f;
    public float acceleration;
    public float deceleration;
    int velocityZHash;
    int velocityXHash;

    void Start() {
        animator = GetComponent<Animator>();
        velocityZHash = Animator.StringToHash("VelocityZ");
        velocityXHash = Animator.StringToHash("VelocityX");
    }

    void Update() {
        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool runPressed = Input.GetKey(KeyCode.LeftShift);
        bool rightPressed = Input.GetKey(KeyCode.D);
        bool leftPressed = Input.GetKey(KeyCode.A);

        if (forwardPressed && velocityZ < 0.5f && !runPressed) {
            velocityZ += Time.deltaTime * acceleration;
            velocityZ = Mathf.Clamp(velocityZ, 0f, 0.5f);
        }
        if (forwardPressed && velocityZ < 2f && runPressed) {
            velocityZ += Time.deltaTime * acceleration;
            velocityZ = Mathf.Clamp(velocityZ, 0f, 2f);
        }
        if (!forwardPressed && velocityZ > 0f) {
            velocityZ -= Time.deltaTime * deceleration;
        }
        if (forwardPressed && velocityZ > 0.5f && !runPressed) {
            velocityZ -= Time.deltaTime * deceleration;
        }
        if (velocityZ < 0f) {
            velocityZ = 0f;
        }
        animator.SetFloat(velocityZHash, velocityZ);

        if (rightPressed && velocityX < 0.5f && !runPressed) {
            velocityX += Time.deltaTime * acceleration;
            velocityX = Mathf.Clamp(velocityX, -0.5f, 0.5f);
        }
        if (rightPressed && velocityX > 0.5f && !runPressed) {
            velocityX -= Time.deltaTime * deceleration;
        }
        if (rightPressed && velocityX < 2f && runPressed) {
            velocityX += Time.deltaTime * acceleration;
            velocityX = Mathf.Clamp(velocityX, -2f, 2f);
        }
        if (leftPressed && velocityX > -0.5f && !runPressed) {
            velocityX -= Time.deltaTime * acceleration;
            velocityX = Mathf.Clamp(velocityX, -0.5f, 0.5f);
        }
        if (leftPressed && velocityX < -0.5f && !runPressed) {
            velocityX += Time.deltaTime * deceleration;
        }
        if (leftPressed && velocityX > -2f && runPressed) {
            velocityX -= Time.deltaTime * acceleration;
            velocityX = Mathf.Clamp(velocityX, -2f, 2f);
        }
        if (!rightPressed && !leftPressed) {
            if (velocityX < 0f) {
                velocityX += deceleration * Time.deltaTime;
            } else if (velocityX > 0f) {
                velocityX -= deceleration * Time.deltaTime;
            }
            if (Mathf.Abs(velocityX) <= 0.05f) {
                velocityX = 0f;
            }
        }
        animator.SetFloat(velocityXHash, velocityX);
        velocityX = Mathf.Clamp(velocityX, -2f, 2f);
    }
}
