using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUtilsList {
    List<T> SchuffleList<T>(List<T> list) where T : class;
}
