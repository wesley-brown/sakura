using System;
using System.Collections.Generic;
using UnityEngine;

public sealed class SakuraInput : MonoBehaviour
{
    private const int Num_Mouse_Buttons = 6;
    private bool[] latestMouseButtonsDown = new bool[Num_Mouse_Buttons];
    private bool[] latestMouseButtons = new bool[Num_Mouse_Buttons];
    private Vector3? latestMousePosition = Vector3.zero;

    private List<Touch> latestTouches = new List<Touch>();
    private int numFixedUpdatesThisFrame = 0;

    private void FixedUpdate()
    {
        if (RanAtLeastOneFixedUpdateThisFrame())
        {
            ClearLatestTouches();
            ClearMouseButtonsDown();
            ClearMouseButtons();
            ClearLatestMousePosition();
        }
        else
        {
            RecordLatestTouches();
            RecordLatestMouseButtonsDown();
            RecordLatestMouseButtons();
            RecordLatestMousePosition();
            numFixedUpdatesThisFrame++;
        }
    }

    private bool RanAtLeastOneFixedUpdateThisFrame()
    {
        return numFixedUpdatesThisFrame > 0;
    }

    private void ClearLatestTouches()
    {
        latestTouches = new List<Touch>();
    }

    private void RecordLatestTouches()
    {
        latestTouches = new List<Touch>(Input.touches);
    }

    private void ClearMouseButtonsDown()
    {
        latestMouseButtonsDown = new bool[Num_Mouse_Buttons];
    }

    private void RecordLatestMouseButtonsDown()
    {
        for (
            var mouseButton = 0;
            mouseButton < Num_Mouse_Buttons;
            mouseButton++)
        {
            if (Input.GetMouseButtonDown(mouseButton))
                latestMouseButtonsDown[mouseButton] = true;
        }
    }

    private void ClearMouseButtons()
    {
        latestMouseButtons = new bool[Num_Mouse_Buttons];
    }

    private void RecordLatestMouseButtons()
    {
        for (
            var mouseButton = 0;
            mouseButton < Num_Mouse_Buttons;
            mouseButton++)
        {
            if (Input.GetMouseButton(mouseButton))
                latestMouseButtons[mouseButton] = true;
        }
    }

    private void ClearLatestMousePosition()
    {
        latestMousePosition = null;
    }

    private void RecordLatestMousePosition()
    {
        latestMousePosition = Input.mousePosition;
    }

    private void Update()
    {
        if (RanAtLeastOneFixedUpdateThisFrame())
        {
            ClearLatestTouches();
            ClearMouseButtonsDown();
            ClearMouseButtons();
            ClearLatestMousePosition();
            numFixedUpdatesThisFrame = 0;
        }
        else
        {
            RecordLatestTouches();
            RecordLatestMouseButtonsDown();
            RecordLatestMouseButtons();
            RecordLatestMousePosition();
        }
    }

    public Vector3 mousePosition
    {
        get
        {
            return latestMousePosition != null
                ? latestMousePosition.Value
                : Input.mousePosition;
        }
    }

    /// <summary>
    ///     Number of touches. Guaranteed not to change throughout the frame.
    ///     (Read Only)
    /// </summary>
    public int touchCount
    {
        get
        {
            Debug.Assert(latestTouches != null);
            return latestTouches.Count;
        }
    }

    /// <summary>
    ///   <para>Returns whether the given mouse button is held down.</para>
    /// </summary>
    /// <param name="button"></param>
    public bool GetMouseButton(int button)
    {
        if (button < 0 || button > Num_Mouse_Buttons - 1)
            throw new ArgumentException("Invalid mouse button index.");
        return latestMouseButtons[button];
    }

    /// <summary>
    ///   Returns true during the frame the user pressed the given mouse
    ///   button.
    /// </summary>
    /// <param name="button">The button.</param>
    public bool GetMouseButtonDown(int button)
    {
        if (button < 0 || button > Num_Mouse_Buttons - 1)
            throw new ArgumentException("Invalid mouse button index.");
        return latestMouseButtonsDown[button];
    }

    /// <summary>
    ///     Call Input.GetTouch to obtain a Touch struct.
    /// </summary>
    /// <param name="index">
    ///     The touch input on the device screen.
    /// </param>
    /// <returns>
    ///     Touch details in the struct.
    /// </returns>
    /// <exception cref="ArgumentException">
    ///     Thrown when the given index < 0.
    /// </exception>
    public Touch GetTouch(int index)
    {
        Debug.Assert(latestTouches != null);
        if (index < 0)
            throw new ArgumentException("Index out of bounds.");
        return latestTouches[index];
    }
}
