using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG4Team
{
     public interface IScene
     {
          void Awake();
          void Start();
          void End();
     }
}
