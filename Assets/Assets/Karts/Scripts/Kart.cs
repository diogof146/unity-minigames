using UnityEngine;

namespace Karts {

  public interface Kart {
    int currentLap { get; }
    int currentWaypoint { get; }
    float distance { get; }
  }
}
