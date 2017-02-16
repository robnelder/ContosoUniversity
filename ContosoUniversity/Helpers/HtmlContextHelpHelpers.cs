using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using ContosoUniversity.Models;

namespace ContosoUniversity.Helpers
{
    public static class HtmlContextHelpHelpers
    {
        private const string EDITORROLE = "ContextHelpEditor"; 

        #region " Display Help "
        /// <summary>
        ///     Returns HTML markup to display a context sensitive help icon with a popover to display 
        ///     the help. This overload does not provide an editor link. DisplayHelp displays the icons 
        ///     and context sensitive help only, DisplayNameWithHelp also provides a caption which 
        ///     can have a tooltip.
        /// </summary>
        /// <param name="helper">The HTML helper instance that this method extends.</param>
        /// <param name="title">The title to appear in bold at the top of the context help popover.</param>
        /// <param name="content">The text to appear in the body of the popover (can include HTML formatting).</param>
        /// <returns>HTML markup in an MvcHtmlString</returns>
        public static MvcHtmlString DisplayHelp(this HtmlHelper helper, string title, string content)
        {
            return DisplayNameWithHelp(null, title, content, null, null);
        }

        /// <summary>
        ///     Returns HTML markup to display a context sensitive help icon with a popover to display 
        ///     the help. This overload is intended to be used for context help for the page rather than
        ///     individual controls. This overload provides an editor link, enabling members of the 'ContextHelpEditor' 
        ///     role to edit the help text. DisplayHelp displays the icons and context sensitive help only
        ///     , DisplayNameWithHelp also provides a caption which can have a tooltip.
        /// </summary>
        /// <param name="helper">The HTML helper instance that this method extends.</param>
        /// <param name="contextHelps">An IEnumerable containing ContextHelp objects holding the data required for the popovers.</param>
        /// <returns>HTML markup in an MvcHtmlString</returns>
        public static MvcHtmlString DisplayHelp(this HtmlHelper helper, IEnumerable<ContextHelp> contextHelps)
        {
            return DisplayNameWithHelp(null, null, helper.ViewContext, contextHelps);
        }

        /// <summary>
        ///     Returns HTML markup to display a context sensitive help icon with a popover to display 
        ///     help for the object identified by expression. This overload provides an editor link, 
        ///     enabling members of the 'ContextHelpEditor' role to edit the help text. DisplayHelpFor 
        ///     displays the icons and context sensitive help only, DisplayNameWithHelpFor also provides 
        ///     a caption which can have a tooltip.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="helper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to display.</param>
        /// <param name="contextHelps">An IEnumerable containing ContextHelp objects holding the data required for the popovers.</param>
        /// <returns>HTML markup in an MvcHtmlString</returns>
        public static MvcHtmlString DisplayHelpFor<TModel,TValue>(this HtmlHelper<IEnumerable<TModel>> helper, Expression<Func<TModel, TValue>> expression, IEnumerable<ContextHelp> contextHelps)
        {
            var metadata = GetMetaDataFor(helper, expression);
            return DisplayNameWithHelp(null, metadata, helper.ViewContext, contextHelps);
        }

        /// <summary>
        ///     Returns HTML markup to display a context sensitive help icon with a popover to display 
        ///     help for the object identified by expression. This overload provides an editor link, 
        ///     enabling members of the 'ContextHelpEditor' role to edit the help text. DisplayHelpFor 
        ///     displays the icons and context sensitive help only, DisplayNameWithHelpFor also provides 
        ///     a caption which can have a tooltip.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="helper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to display.</param>
        /// <param name="contextHelps">An IEnumerable containing ContextHelp objects holding the data required for the popovers.</param>
        /// <returns>HTML markup in an MvcHtmlString</returns>
        public static MvcHtmlString DisplayHelpFor<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, IEnumerable<ContextHelp> contextHelps)
        {
            var metadata = GetMetaDataFor(helper, expression);
            return DisplayNameWithHelp(null, metadata, helper.ViewContext, contextHelps);
        }
        #endregion " Display Help "

        #region " Display Name and Help "
        /// <summary>
        ///     Returns HTML markup to display a label with a tooltip and/or a context sensitive help icon 
        ///     with a popover to display the help. This overload does not provide an editor link. 
        ///     For a help icon with popover but no label or tooltip see DisplayHelp.
        /// </summary>
        /// <param name="helper">The HTML helper instance that this method extends.</param>
        /// <param name="name">The name to appear in the label and also in bold at the top of the context help popover.</param>
        /// <param name="content">The text to appear in the body of the popover (can include HTML formatting).</param>
        /// <param name="tooltip">The text to appear in the tooltip.</param>
        /// <returns>HTML markup in an MvcHtmlString</returns>
        public static MvcHtmlString DisplayNameWithHelp(this HtmlHelper helper, string name, string content, string tooltip)
        {
            return DisplayNameWithHelp(name, name, content, tooltip, null);
        }

        /// <summary>
        ///     Returns HTML markup to display a label with a tooltip and/or a context sensitive help icon 
        ///     with a popover to display the help. This overload is intended to be used for the page rather than
        ///     individual controls. This overload provides an editor link, enabling members of the 'ContextHelpEditor' 
        ///     role to edit the help text. For a help icon with popover but no label or tooltip see DisplayHelp.
        /// </summary>
        /// <param name="helper">The HTML helper instance that this method extends.</param>
        /// <param name="contextHelps">An IEnumerable containing ContextHelp objects holding the data required for the popovers.</param>
        /// <returns>HTML markup in an MvcHtmlString</returns>
        public static MvcHtmlString DisplayNameWithHelp(this HtmlHelper helper, IEnumerable<ContextHelp> contextHelps)
        {
            return DisplayNameWithHelp(null, helper.ViewContext, contextHelps);
        }

        /// <summary>
        ///     Returns HTML markup to display a label with a tooltip and/or a context sensitive help icon 
        ///     with a popover to display the help for the object identified by expression.
        ///     This overload provides an editor link, enabling members of the 'ContextHelpEditor' role to edit 
        ///     the help text. For a help icon with popover but no label or tooltip see DisplayHelpFor. 
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="helper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to display.</param>
        /// <param name="contextHelps">An IEnumerable containing ContextHelp objects holding the data required for the popovers.</param>
        /// <returns>HTML markup in an MvcHtmlString</returns>
        public static MvcHtmlString DisplayNameWithHelpFor<TModel, TValue>(this HtmlHelper<IEnumerable<TModel>> helper, Expression<Func<TModel, TValue>> expression, IEnumerable<ContextHelp> contextHelps)
        {
            var metadata = GetMetaDataFor(helper, expression);
            return DisplayNameWithHelp(metadata, helper.ViewContext, contextHelps);
        }

        /// <summary>
        ///     Returns HTML markup to display a label with a tooltip and/or a context sensitive help icon 
        ///     with a popover to display the help for the object identified by expression.
        ///     This overload provides an editor link, enabling members of the 'ContextHelpEditor' role to edit 
        ///     the help text. For a help icon with popover but no label or tooltip see DisplayHelpFor. 
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="helper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to display.</param>
        /// <param name="contextHelps">An IEnumerable containing ContextHelp objects holding the data required for the popovers.</param>
        /// <returns>HTML markup in an MvcHtmlString</returns>
        public static MvcHtmlString DisplayNameWithHelpFor<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, IEnumerable<ContextHelp> contextHelps)
        {
            var metadata = GetMetaDataFor(helper, expression);            
            return DisplayNameWithHelp(metadata, helper.ViewContext, contextHelps);
        }

        /// <summary>
        /// (private) Returns HTML markup to display a label with a tooltip and/or a context sensitive help icon 
        ///     with a popover to display the help for the object identified by expression.
        ///     Provides an editor link enabling members of the 'ContextHelpEditor' role to edit 
        ///     the help text.
        /// </summary>
        /// <param name="metadata">ModelMetadata object providing metadata for the object that contains the properties to display.</param>
        /// <param name="viewContext">ViewContext object providing information from the View being rendered.</param>
        /// <param name="contextHelps">An IEnumerable containing ContextHelp objects holding the data required for the popovers.</param>
        /// <returns>HTML markup in an MvcHtmlString</returns>
        private static MvcHtmlString DisplayNameWithHelp(ModelMetadata metadata, ViewContext viewContext, IEnumerable<ContextHelp> contextHelps)
        {
            string name = GetFieldOrControllerName(metadata, viewContext);
            return DisplayNameWithHelp(name, metadata, viewContext, contextHelps);
        }

        /// <summary>
        /// (private) Returns HTML markup to display a label with a tooltip and/or a context sensitive help icon 
        ///     with a popover to display the help for the object identified by expression.
        ///     Provides an editor link enabling members of the 'ContextHelpEditor' role to edit 
        ///     the help text.
        /// </summary>
        /// <param name="name">The name to appear in the label. 
        ///     Can be null, in which case no label or tooltip will be displayed.</param>
        /// <param name="title">The title to appear in bold at the top of the context help popover. 
        ///     Can be null, in which case no help context popover will be displayed.</param>
        /// <param name="content">The text to appear in the body of the popover (can include HTML formatting). 
        ///     Can be null, in which case no help context popover will be displayed.</param>
        /// <param name="tooltip">The text to appear in the tooltip.
        ///     Can be null, in which case no tooltip will be displayed.</param>
        /// <param name="editorHTML">HTML markup required to display link for editor.</param>                
        /// <param name="tooltip">The text to appear in the tooltip.</param>
        /// <returns>HTML markup in an MvcHtmlString</returns>
        private static MvcHtmlString DisplayNameWithHelp(string name, string title, string content, string tooltip, string editorHTML)
        {
            // TODO: figure out how to position the popover so that top is no higher than the link
            // TODO: Make tooltips look better
            // TODO: figure out how to reposition the popover when screen size changes   
                                             
            // Build ContextHelp span which will display the question mark with a popover
            var contextHelp = new TagBuilder("span");
            contextHelp.AddCssClass("glyphicon");
            contextHelp.AddCssClass("glyphicon-question-sign");
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(content))
            {
                if (!string.IsNullOrWhiteSpace(editorHTML))
                {
                    contextHelp.Attributes.Add("style", "color: lightgray; font-size:14px");
                }
                else
                {
                    contextHelp.Attributes.Add("style", "color: transparent; font-size:14px");
                }
            }
            else
            {
                contextHelp.Attributes.Add("tabindex", "0");
                contextHelp.Attributes.Add("role", "button");
                contextHelp.Attributes.Add("style", "color: dodgerblue; font-size:14px");
                contextHelp.Attributes.Add("data-toggle", "popover");
                contextHelp.Attributes.Add("data-html", "true");
                contextHelp.Attributes.Add("data-title", "<strong>" + title + "</strong>");
                contextHelp.Attributes.Add("data-content", content);
                contextHelp.Attributes.Add("data-trigger", "focus");
                contextHelp.Attributes.Add("data-placement", "right");
                contextHelp.Attributes.Add("data-container", "body");
            }
            // Build the outer span which will contain the name (if specified), the ContextHelp, and the editorHTML (if relevant)
            var noWrapContainer = new TagBuilder("span");
            noWrapContainer.Attributes.Add("style", "white-space: nowrap;");
            System.Text.StringBuilder ret = new System.Text.StringBuilder("<span style='white-space: nowrap;'>");
            if (!string.IsNullOrWhiteSpace(name))
            {
                if (!string.IsNullOrWhiteSpace(tooltip))
                {
                    var nameWithToolTip = new TagBuilder("span");
                    nameWithToolTip.InnerHtml = name + " ";
                    nameWithToolTip.Attributes.Add("data-toggle", "tooltip");
                    nameWithToolTip.Attributes.Add("data-placement", "bottom");
                    nameWithToolTip.Attributes.Add("data-container", "body");
                    nameWithToolTip.Attributes.Add("data-trigger", "hover");
                    nameWithToolTip.Attributes.Add("title", tooltip);
                    noWrapContainer.InnerHtml = nameWithToolTip.ToString();
                }
                else
                {
                    noWrapContainer.InnerHtml = name + " ";
                }
            }
            noWrapContainer.InnerHtml += contextHelp.ToString();
            if (!string.IsNullOrWhiteSpace(editorHTML)) noWrapContainer.InnerHtml += " " + editorHTML;

            return MvcHtmlString.Create(noWrapContainer.ToString());
        }

        /// <summary>
        /// (private) Returns HTML markup to display a label with a tooltip and/or a context sensitive help icon 
        ///     with a popover to display the help for the object identified by expression.
        ///     Provides an editor link enabling members of the 'ContextHelpEditor' role to edit 
        ///     the help text.
        /// </summary>
        /// <param name="name">The name to appear in the label. 
        ///     Can be null, in which case no label or tooltip will be displayed.</param>
        /// <param name="metadata">ModelMetadata object providing metadata for the object that contains the properties to display.</param>
        /// <param name="viewContext">ViewContext object providing information from the View being rendered.</param>
        /// <param name="contextHelps">An IEnumerable containing ContextHelp objects holding the data required for the popovers.</param>
        /// <returns>HTML markup in an MvcHtmlString</returns>
        private static MvcHtmlString DisplayNameWithHelp(string name, ModelMetadata metadata, ViewContext viewContext, IEnumerable<ContextHelp> contextHelps)
        {
            /*  
                Name must be passed in rather than got from viewContext (like title is)
                because this fn is called by public DisplayHelp methods (i.e. without name & intended to show help only)
            */
            string title = GetFieldOrControllerName(metadata, viewContext);
            string content = GetContextHelpContent(metadata, viewContext, contextHelps);
            string tooltip = GetTooltip(metadata, viewContext, contextHelps);
            bool isEditor = GetIsEditor(viewContext);
            if (isEditor)
            {
                string editHelpLink = "/ContextHelp/";
                int? contextHelpID = GetContextHelpID(metadata, viewContext, contextHelps);
                // If there is data there already then edit it, else add new
                if (contextHelpID != null)
                {
                    editHelpLink += "Edit/" + contextHelpID.ToString();
                }
                else // There is no help data for this item yet, create it
                {
                    editHelpLink += "Create"
                                    + "?cont=" + GetControllerName(viewContext)
                                    + "&act=" + GetActionName(viewContext); 
                    string prop = GetPropertyName(metadata);
                    if (!string.IsNullOrWhiteSpace(prop)) editHelpLink += "&prop=" + prop;
                }
                var contextHelpEditor = new TagBuilder("a");
                contextHelpEditor.AddCssClass("glyphicon");
                contextHelpEditor.AddCssClass("glyphicon-edit");
                contextHelpEditor.MergeAttribute("href", editHelpLink);
                contextHelpEditor.MergeAttribute("style", "color: gray; font-size:14px; text-decoration: none");
                contextHelpEditor.MergeAttribute("tabindex", "0");
                return MvcHtmlString.Create(DisplayNameWithHelp(name, title, content, tooltip, contextHelpEditor.ToString()).ToString());
            }
            else
            {
                return MvcHtmlString.Create(DisplayNameWithHelp(name, title, content, tooltip, null).ToString());
            }
        }
        #endregion " Display Name and Help "

        #region " Get Context Help Info "
        /// <summary>
        /// Gets the text to be displayed in the body of a context help popover 
        /// for the object identified by the metadata and viewContext information.
        /// </summary>
        /// <param name="metadata">ModelMetadata object providing metadata for the object that contains the properties to display.</param>
        /// <param name="viewContext">ViewContext object providing information from the View being rendered.</param>
        /// <param name="contextHelps">An IEnumerable containing ContextHelp objects holding the data required for the popovers.</param>
        /// <returns>Text to be displayed in the body of a context help popover.</returns>
        private static string GetContextHelpContent(ModelMetadata metadata, ViewContext viewContext, IEnumerable<ContextHelp> contextHelps)
        {
            // Get HelpText for top item or return null if none found
            return GetContextHelp(metadata, viewContext, contextHelps)?.HelpText;
        }

        /// <summary>
        /// Gets the text to be displayed in the tooltip  
        /// for the object identified by the metadata and viewContext information.
        /// </summary>
        /// <param name="metadata">ModelMetadata object providing metadata for the object that contains the properties to display.</param>
        /// <param name="viewContext">ViewContext object providing information from the View being rendered.</param>
        /// <param name="contextHelps">An IEnumerable containing ContextHelp objects holding the data required for the popovers.</param>
        /// <returns>Text to be displayed in the tooltip.</returns>
        private static string GetTooltip(ModelMetadata metadata, ViewContext viewContext, IEnumerable<ContextHelp> contextHelps)
        {
            // Get HelpText for top item or return null if none found
            return GetContextHelp(metadata, viewContext, contextHelps)?.Tooltip;
        }

        /// <summary>
        /// Gets the ID of the ContextHelp object containing the relevant tooltip and help information  
        /// for the object identified by the metadata and viewContext information.
        /// </summary>
        /// <param name="metadata">ModelMetadata object providing metadata for the object that contains the properties to display.</param>
        /// <param name="viewContext">ViewContext object providing information from the View being rendered.</param>
        /// <param name="contextHelps">An IEnumerable containing ContextHelp objects holding the data required for the popovers.</param>
        /// <returns>ID of the ContextHelp object containing the relevant tooltip and help information.</returns>
        private static int? GetContextHelpID(ModelMetadata metadata, ViewContext viewContext, IEnumerable<ContextHelp> contextHelps)
        {
            // Get HelpID for top item or return null if none found
            return GetContextHelp(metadata, viewContext, contextHelps)?.ContextHelpID;
        }

        /// <summary>
        /// Gets the ContextHelp object containing the relevant tooltip and help information  
        /// for the object identified by the metadata and viewContext information.
        /// </summary>
        /// <param name="metadata">ModelMetadata object providing metadata for the object that contains the properties to display.</param>
        /// <param name="viewContext">ViewContext object providing information from the View being rendered.</param>
        /// <param name="contextHelps">An IEnumerable containing ContextHelp objects holding the data required for the popovers.</param>
        /// <returns>ContextHelp object containing the relevant tooltip and help information.</returns>
        private static ContextHelp GetContextHelp(ModelMetadata metadata, ViewContext viewContext, IEnumerable<ContextHelp> contextHelps)
        {
            var controllerName = GetControllerName(viewContext);
            var actionName = viewContext.Controller.ValueProvider.GetValue("action").RawValue.ToString();
            var propertyName = metadata?.PropertyName;
            return GetContextHelp(controllerName, actionName, propertyName, contextHelps);
        }

        /// <summary>
        /// Gets the ContextHelp object containing the relevant tooltip and help information  
        /// for the object identified by the properties provided. Prioritises entries with Property and Action
        /// , then entries with Property and no Action, then entries with Action and no Property, then the entry
        /// for Controller only.
        /// </summary>
        /// <param name="controllerName">Name of the Controller that is responsible for the View.</param>
        /// <param name="actionName">Name of the relevant Action that is used to produce the web page. 
        ///     Can be null, in which case the Controller's default data is returned (for the specified Property if relevant).</param>
        /// <param name="propertyName">Name of the property (field) that tooltip or help content is required for.
        ///     Can be null, in which case the content is relevant to the web page rather than a single control.</param>
        /// <param name="contextHelps">An IEnumerable containing ContextHelp objects holding the data required for the popovers.</param>
        /// <returns>ContextHelp object containing the relevant tooltip and help information.</returns>
        private static ContextHelp GetContextHelp(string controllerName, string actionName, string propertyName, IEnumerable<ContextHelp> contextHelps)
        {
            return contextHelps
                    .Where(ch => ch.Controller == controllerName)                                   // Controller names match
                    .Where(ch => string.IsNullOrWhiteSpace(ch.Action) || ch.Action == actionName)   // Stored Action is Null or Actions match
                    .Where(ch => ch.Property == propertyName)                                       // Property names match (note both can be null)
                    .OrderBy(ch => !string.IsNullOrWhiteSpace(ch.Property) ? 0 : 1)                 // Prioritise entries where Property is specified
                    .ThenBy(ch => !string.IsNullOrWhiteSpace(ch.Action) ? 0 : 1)                    // Prioritise entries where Action is specified                        
                    .FirstOrDefault();                                                              // Get top item or return null if none found
        }
        #endregion " Get Context Help Content "

        /// <summary>
        /// Gets a ModelMetadata object containing metadata information about the object identified by the parameters (the object
        /// that tooltip/context help data is required for).
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="helper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to display.</param>
        /// <returns>ModelMetadata for the object identified by the parameters provided.</returns>
        private static ModelMetadata GetMetaDataFor<TModel, TValue>(this HtmlHelper<IEnumerable<TModel>> helper, Expression<Func<TModel, TValue>> expression)
        {
            var name = ExpressionHelper.GetExpressionText(expression);
            name = helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            return ModelMetadataProviders.Current.GetMetadataForProperty(() => Activator.CreateInstance<TModel>(), typeof(TModel), name);
        }

        /// <summary>
        /// Gets a ModelMetadata object containing metadata information about the object identified by the parameters (the object
        /// that tooltip/context help data is required for).
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="helper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to display.</param>
        /// <returns>ModelMetadata for the object identified by the parameters provided.</returns>
        private static ModelMetadata GetMetaDataFor<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression)
        {
            return ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
        }

        /// <summary>
        /// Gets the name of the Controller associated with a View using its ViewContext.
        /// </summary>
        /// <param name="viewContext">ViewContext for the View whose Controller name is required.</param>
        /// <returns>The name of the Controller associated with the relevant View.</returns>
        private static string GetControllerName(ViewContext viewContext)
        {
            return viewContext.Controller.ValueProvider.GetValue("controller").RawValue.ToString();
        }

        /// <summary>
        /// Gets the name of the Action associated with a View using its ViewContext.
        /// </summary>
        /// <param name="viewContext">ViewContext for the View whose Action name is required.</param>
        /// <returns>The name of the Action associated with the relevant View.</returns>
        private static string GetActionName(ViewContext viewContext)
        {
            return viewContext.Controller.ValueProvider.GetValue("action").RawValue.ToString();
        }

        /// <summary>
        /// Gets the Display Name for the Property identified by the metadata if it has one, else its PropertyName.
        /// </summary>
        /// <param name="metadata">ModelMetada describing the property whose name is required.</param>
        /// <returns>The name to be displayed for the identified Property.</returns>
        private static string GetFieldName(ModelMetadata metadata)
        {
            return metadata?.DisplayName ?? metadata?.PropertyName;
        }

        /// <summary>
        /// Gets the name of the Property identified by the metadata.
        /// </summary>
        /// <param name="metadata">ModelMetada describing the property whose name is required.</param>
        /// <returns>The name of the Property identified by the ModelMetadata object.</returns>
        private static string GetPropertyName(ModelMetadata metadata)
        {
            return metadata?.PropertyName;
        }

        /// <summary>
        /// If metadata has been passed in then gets the DisplayName for the Property identified if it has one
        /// else gets its PropertyName. If metadata is null then gets the name of the Controller identified
        /// using viewContext.
        /// </summary>
        /// <param name="metadata">ModelMetada describing the property whose name is required.</param>
        /// <param name="viewContext">ViewContext for the View whose Action name is required.</param>
        /// <returns>Name to be displayed for the Property or Controller identified using metadata and viewContext.</returns>
        private static string GetFieldOrControllerName(ModelMetadata metadata, ViewContext viewContext)
        {
            if (metadata != null) // we've had a property passed in
            {
                return GetFieldName(metadata);
            }
            else // no property passed in so use controller name
            {
                return GetControllerName(viewContext);
            }
        }

        /// <summary>
        /// Indicates if current user is a member of the ContextHelpEditor role and therefore entitled to
        /// edit tooltip and context help data.
        /// </summary>
        /// <param name="viewContext">ViewContext for the View whose Action name is required.</param>
        /// <returns>True if current User is a member of the ContextHelpEditor role.</returns>
        private static bool GetIsEditor(ViewContext viewContext)
        {
            if (viewContext == null) return false;
            return GetControllerName(viewContext) != "ContextHelp"; // TODO: Delete this!
            return viewContext.HttpContext.User.IsInRole(EDITORROLE);
        }
    }
}

/*

[Basic instructions for adding context help functionality to a Model (kind of assumes you are copying from an example.)]
(scaffold Controller and Views using Visual Studio built in functionality.)

Tooltips and popovers need to be initialised. If they're used on most pages then it might be best to do this in _Layout.cshtml

Create ViewModel
Edit Controller
	Add GetViewModel private methods
	Edit ActionResult methods to use GetViewModel when passing the model to the views
Edit Views
	Index 	
		change @model
		add DisplayHelp to <h2> at top of page
		change DisplayNameFor to DisplayNameWithHelpFor
		change @foreach to use Model.IEnumerable<T>
		edit model.property references to use ViewModel
	Create, Edit	
		change @model
		add DisplayHelp to <h2> at top of page
		Replace each LabelFor with DisplayNameWithHelpFor wrapped in a <div class="col-md-2 text-right label-control"><strong>
		remove the col-md-2 class from each LabelFor
		edit model.property references to use ViewModel
	Details, Delete 	
		change @model
		add DisplayHelp to <h2> at top of page
		change DisplayNameFor to DisplayNameWithHelpFor
		edit model.property references to use ViewModel		 

*/
