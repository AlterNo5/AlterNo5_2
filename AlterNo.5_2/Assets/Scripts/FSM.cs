using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class FSM
{
    private Action m_enterState;
    private Action m_updateState;
    private Action m_exitState;

    private int m_desiredState = -1;
    private int m_currentState = -1;

    public int GetCurrentState
    {
        get { return m_currentState; }
    }

    public void InitStateMachine(Action enter, Action update, int state)
    {
        m_enterState = enter;
        m_updateState = update;
        m_desiredState = state;
    }

    public void UpdateStateMachine()
    {
        if (m_desiredState == -1) { return; }

        if (m_desiredState != m_currentState)
        {
            m_exitState?.Invoke();
            m_enterState?.Invoke();
            m_currentState = m_desiredState;
        }
        else
        {
            m_updateState?.Invoke();
        }

    }

    public void ChangeState(Action enter, Action update, Action oldexit, int state)
    {
        m_enterState = enter;
        m_updateState = update;
        m_exitState = oldexit;
        m_desiredState = state;
    }


}
