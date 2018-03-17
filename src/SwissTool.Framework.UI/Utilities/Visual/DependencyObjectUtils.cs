// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DependencyObjectUtils.cs" company="Fredrik Winkvist">
//   Copyright (c) Fredrik Winkvist. All rights reserved.
// </copyright>
// <summary>
//   Defines the DependencyObjectUtils type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SwissTool.Framework.UI.Utilities.Visual
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Media;

    /// <summary>
    /// The dependency object helper class.
    /// </summary>
    public static class DependencyObjectUtils
    {
        /// <summary>
        /// Gets the first type of the descendant of.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="parent">The parent.</param>
        /// <returns>The first descendant object.</returns>
        public static T GetFirstDescendantOfType<T>(DependencyObject parent) 
            where T : DependencyObject
        {
            if (parent == null)
            {
                return null;
            }

            var children = GetChildren(parent).ToList();
            var descendant = children.FirstOrDefault(child => child is T) as T;

            if (descendant == null)
            {
                foreach (var child in children)
                {
                    if ((descendant = GetFirstDescendantOfType<T>(child)) != null)
                    {
                        break;
                    }
                }
            }

            return descendant;
        }

        /// <summary>
        /// Gets the children.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <returns>The children.</returns>
        public static IEnumerable<DependencyObject> GetChildren(DependencyObject parent)
        {
            var children = new List<DependencyObject>();

            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                children.Add(VisualTreeHelper.GetChild(parent, i));
            }

            return children;
        }

        /// <summary>
        /// Finds the child.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="parent">The parent.</param>
        /// <param name="childName">Name of the child.</param>
        /// <returns>The child element.</returns>
        public static T FindChild<T>(DependencyObject parent, string childName) 
            where T : DependencyObject
        {
            // Confirm parent and childName are valid. 
            if (parent == null)
            {
                return null;
            }

            T foundChild = null;

            var childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (var i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);

                // If the child is not of the request child type child
                var childType = child as T;
                if (childType == null)
                {
                    // recursively drill down the tree
                    foundChild = FindChild<T>(child, childName);

                    // If the child is found, break so we do not overwrite the found child. 
                    if (foundChild != null)
                    {
                        break;
                    }
                }
                else if (!string.IsNullOrEmpty(childName))
                {
                    var frameworkElement = child as FrameworkElement;

                    // If the child's name is set for search
                    if (frameworkElement != null && frameworkElement.Name == childName)
                    {
                        // if the child's name is of the request name
                        foundChild = (T)child;
                        break;
                    }
                }
                else
                {
                    // child element found.
                    foundChild = (T)child;
                    break;
                }
            }

            return foundChild;
        }

        /// <summary>
        /// Finds the children of a specific type.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="parent">The parent.</param>
        /// <returns>The children.</returns>
        public static IEnumerable<T> FindChildren<T>(DependencyObject parent) where T : DependencyObject
        {
            var childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (var i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);

                var childType = child as T;
                if (childType == null)
                {
                    foreach (var other in FindChildren<T>(child))
                    {
                        yield return other;
                    }
                }
                else
                {
                    yield return (T)child;
                }
            }
        }

        /// <summary>
        /// Finds the type of the child of.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="depObj">The dependency object.</param>
        /// <returns>The child.</returns>
        public static T FindChildOfType<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj == null)
            {
                return null;
            }

            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                var child = VisualTreeHelper.GetChild(depObj, i);

                var result = (child as T) ?? FindChildOfType<T>(child);
                if (result != null)
                {
                    return result;
                }
            }

            return null;
        }

        /// <summary>
        /// Finds the visual parent.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="child">The child.</param>
        /// <returns>The visual parent.</returns>
        public static T FindVisualParent<T>(DependencyObject child) where T : DependencyObject
        {
            // get parent item
            var parentObject = VisualTreeHelper.GetParent(child);

            // we’ve reached the end of the tree
            if (parentObject == null)
            {
                return null;
            }

            // check if the parent matches the type we’re looking for
            var parent = parentObject as T;

            return parent ?? FindVisualParent<T>(parentObject);
        }
    }
}
