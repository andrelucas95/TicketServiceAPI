﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ORG.TicketService.Data.Database.Scripts {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class TicketSql {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal TicketSql() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ORG.TicketService.Data.Database.Scripts.TicketSql", typeof(TicketSql).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT INTO TICKETS
        ///(TITLE, DESCRIPTION, PRIORITY, OPENEDAT)
        ///VALUES
        ///(@TITLE, @DESCRIPTION, @PRIORITY, @OPENEDAT);.
        /// </summary>
        internal static string INSERT_TICKET {
            get {
                return ResourceManager.GetString("INSERT_TICKET", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT * FROM TICKETS ORDER BY OPENEDAT DESC;.
        /// </summary>
        internal static string SELECT_ALL {
            get {
                return ResourceManager.GetString("SELECT_ALL", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT * FROM TICKETS WHERE Id = @ID;.
        /// </summary>
        internal static string SELECT_TICKET_BY_ID {
            get {
                return ResourceManager.GetString("SELECT_TICKET_BY_ID", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to UPDATE TICKET SET TITLE = @TITLE, DESCRIPTION = @DESCRIPTION, PRIORITY = @PRIORITY, FINISHEDAT = @FINISHEDAT, CANCELEDAT = @CANCELEDAT WHERE ID = @ID;.
        /// </summary>
        internal static string UPDATE_TICKET {
            get {
                return ResourceManager.GetString("UPDATE_TICKET", resourceCulture);
            }
        }
    }
}
