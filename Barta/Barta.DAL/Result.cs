// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Result.cs" company="Cybk">
//   2012
// </copyright>
// <summary>
//   Container for the operation's result
//   on the Database
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Barta.DAL
{
    /// <summary>
    /// Container for the operation's result 
    /// on the Database
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Result" /> class.
        /// </summary>
        public Result()
        {
            this.Success = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Result" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public Result(string message)
        {
            this.ErrorMessage = message;
            this.Success = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Result" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="rst">if set to <c>true</c> [RST].</param>
        public Result(string message, bool rst)
        {
            this.ErrorMessage = message;
            this.Success = rst;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Result" /> is success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if success; otherwise, <c>false</c>.
        /// </value>
        public bool Success { private get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string ErrorMessage { private get; set; }
    }
}
