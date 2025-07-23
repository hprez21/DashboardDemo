using DashboardDemo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashboardDemo.AttachedProperties
{
    public class RoleManager
    {
        public static BindableProperty VisibilityProperty =
            BindableProperty.CreateAttached("Visibility",
                typeof(UserRole), typeof(RoleManager), UserRole.User);

        public static UserRole GetVisibility(BindableObject view)
        {
            return (UserRole)view.GetValue(VisibilityProperty);
        }

        public static void SetVisibility(BindableObject view, UserRole value)
        {
            view.SetValue(VisibilityProperty, value);
        }

    }
}
