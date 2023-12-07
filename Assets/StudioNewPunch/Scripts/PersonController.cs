using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonController : MonoBehaviour
{
    public Animator animator; // Это ссылка на компонент аниматора. Мы в него будем отправлять значение state
    private int _state; // эту перем. мы и будем передавать в аниматор. Изменяться она будет в методе Update
    
    private void Start()
    {
        animator = GetComponent<Animator>(); // заполняем перем. animator
        // ссылкой на компонент аниматора с персонажа
    }
    
    // 0 - афк
    // 1 - идти вперед = W
    // 2 - бег вперед = shift + W
    // 3 - идти назад = S
    // 4 - идти левым боком = A
    // 5 - бег левым боком = shift + A
    // 6 - идти правым боком = D
    // 7 - бег правым боком = shift + D

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _state = 2;
            }
            else
            {
                _state = 1;
            }
        } 
        else if (Input.GetKey(KeyCode.S))
        {
            _state = 3;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _state = 5;
            }
            else
            {
                _state = 4;
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _state = 7;
            }
            else
            {
                _state = 6;
            }
        }
        else
        {
            _state = 0; // Если ничего не жмем - Стоим.
        }

        animator.SetInteger("State", _state); // отправляем значение переменной _state в аниматор
    }
}
