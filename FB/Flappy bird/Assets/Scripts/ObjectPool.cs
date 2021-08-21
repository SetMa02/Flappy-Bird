﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
   [SerializeField] private GameObject _container;
   [SerializeField] private int _capacity;

   private Camera _camera;

   private List<GameObject> _pool = new List<GameObject>();

   protected void Initialize(GameObject prefab)
   {
      _camera = Camera.main;

      for (int i = 0; i < _capacity; i++)
      {
         GameObject spawned = Instantiate(prefab, _container.transform);
         spawned.SetActive(false);
         
         _pool.Add(spawned);
      }
   }

   protected void DisableObjectAbroadScreen()
   {
      Vector3 disablePoint = _camera.ViewportToWorldPoint( new Vector2(0,0.5f));
      foreach (var VARIABLE in _pool)
      {
         if (VARIABLE.transform.position.x > disablePoint.x)
         {
          VARIABLE.SetActive = false;
         }
      }
   }

   protected bool TryGetObject(out GameObject result)
   {
      result = _pool.FirstOrDefault(p => p.activeSelf == false);
      return result != null;
   }

   public void ResetPool()
   {
      foreach (var VARIABLE in _pool)
      {
         VARIABLE.SetActive(false);
      }
   }
}
