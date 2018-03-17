// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewModelBase.cs" company="Fredrik Winkvist">
//   Copyright (c) Fredrik Winkvist. All rights reserved.
// </copyright>
// <summary>
//   The ViewModel base
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SwissTool.Framework.UI.Infrastructure
{
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Windows.Input;

    using SwissTool.Framework.UI.Commanding;

    /// <summary>
    /// The ViewModel base
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelBase"/> class.
        /// </summary>
        protected ViewModelBase()
        {
            this.CloseCommand = new RelayCommand(o => this.Close());
        }

        /// <summary>
        /// Occurs when [request close].
        /// </summary>
        public event Action RequestClose;

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets the close command.
        /// </summary>
        /// <value>The close command.</value>
        public ICommand CloseCommand { get; private set; }

        /// <summary>
        /// Closes this instance.
        /// </summary>
        protected virtual void Close()
        {
            this.RequestClose?.Invoke();
        }

        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="expression">The expression.</param>
        protected void NotifyPropertyChanged<T>(Expression<Func<T>> expression)
        {
            this.NotifyPropertyChanged(GetProperty(expression).Name);
        }

        /// <summary>
        /// Gets the property.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns>The property info.</returns>
        /// <exception cref="System.ArgumentException">Not a property expression</exception>
        private static PropertyInfo GetProperty<T>(Expression<Func<T>> expression)
        {
            var property = GetMember(expression) as PropertyInfo;
            if (property == null)
            {
                throw new ArgumentException("Not a property expression", GetMember(() => expression).Name);
            }
 
            return property;
        }

        /// <summary>
        /// Gets the member.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns>The member info.</returns>
        /// <exception cref="System.ArgumentNullException">Argument null.</exception>
        private static MemberInfo GetMember<T>(Expression<Func<T>> expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(GetMember(() => expression).Name);
            }
 
            return GetMemberInfo(expression as LambdaExpression);
        }

        /// <summary>
        /// Gets the member information.
        /// </summary>
        /// <param name="lambda">The lambda.</param>
        /// <returns>The member info.</returns>
        /// <exception cref="System.ArgumentNullException">Argument null.</exception>
        /// <exception cref="System.ArgumentException">Not a member access</exception>
        private static MemberInfo GetMemberInfo(LambdaExpression lambda)
        {
            if (lambda == null)
            {
                throw new ArgumentNullException(GetMember(() => lambda).Name);
            }
 
            MemberExpression memberExpression = null;
            
            switch (lambda.Body.NodeType)
            {
                case ExpressionType.Convert:
                    memberExpression = ((UnaryExpression)lambda.Body).Operand as MemberExpression;
                    break;

                case ExpressionType.MemberAccess:
                    memberExpression = lambda.Body as MemberExpression;
                    break;

                case ExpressionType.Call:
                    return ((MethodCallExpression)lambda.Body).Method;
            }
 
            if (memberExpression == null)
            {
                throw new ArgumentException("Not a member access", GetMember(() => lambda).Name);
            }
 
            return memberExpression.Member;
        }
    }
}
