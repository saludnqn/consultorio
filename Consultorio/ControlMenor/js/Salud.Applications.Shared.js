/*
*
* SALUD.APPLICACIONES.SHARED
* Clases y Namespaces comunes a todas las aplicaciones
*
* (C) Hospital Provincial Neuquen
*
*/

//////////////////////////////////////////////////////////////////////////////////////////////////////
// Browser check
// 09/08/2011 | jgabriel | Por el momento las aplicaciones sólo son compatible con Firefox 4+ e IE9+
//                         En un futuro el control de browser podría hacerse en la autenticación SSO 
//                         para que sea haga una sola vez.
//////////////////////////////////////////////////////////////////////////////////////////////////////

/*
if (!(((/Firefox[\/\s](\d+\.\d+)/.test(navigator.userAgent)) && Number(RegExp.$1) >= 4)
|| ((/Chrome[\/](\d+\.\d+)/.test(navigator.userAgent)) && Number(RegExp.$1) >= 10)
|| ((/MSIE (\d+\.\d+);/.test(navigator.userAgent)) && Number(RegExp.$1) >= 9))) {
window.location.replace('/Resources.Net/browserError.htm');
}
*/

/*
var html5Test = document.createElement('canvas');
if ((!html5Test) || (!html5Test.getContext)) {
window.location.replace('/Resources.Net/browserError.htm');
}
*/


////////////////////////////////////////////
// Global initialization
////////////////////////////////////////////

// Debugging
var debuggingServer = window.location.protocol + '//wwwdev.hospitalneuquen.org.ar/';
var isDebugging = false;
try {
    isDebugging = (window.location.hostname.search(/wwwdev/i) == 0);
} catch (E) {
}

////////////////////////////////////////////
// Namespace initialization
////////////////////////////////////////////
Salud = new Object();
Salud.registerNamespace = function (namespace) {
    var namespaces = namespace.split(".");
    var s = "";
    for (var i = 0; i < namespaces.length; i++) {
        if (!s)
            s = namespaces[i];
        else
            s += "." + namespaces[i];

        //if (eval('typeof(' + s + ') == "undefined"'))
        //eval(s + "= new Object();");
        eval('if (!window.' + s + ') window.' + s + ' = new Object();');
    }
}
Salud.registerNamespace("Salud.Applications.Shared");
Salud.registerNamespace("Salud.Applications.UI");
Salud.registerNamespace("Salud.Applications.UI.Avatar");
Salud.registerNamespace("Salud.Applications.UI.Menu");
Salud.registerNamespace("Salud.Applications.UI.Search");
// Constantes
Salud.Applications.Shared.BasePath = "/dotnet/Shared/";
Salud.Applications.Shared.ThemesPath = "/dotnet/Shared/Themes/";
Salud.Applications.Shared.IntranetPath = "/CMS/";

$(document).ready(function () {
    // Init UI
    Salud.Applications.UI.Skin = new Object();
    var t = document.createElement("DIV");
    t.className = 'color1';
    Salud.Applications.UI.Skin.color1 = $(t).css("backgroundColor");
    t.className = 'color1_light';
    Salud.Applications.UI.Skin.color1_light = $(t).css("backgroundColor");
    t.className = 'color2';
    Salud.Applications.UI.Skin.color2 = $(t).css("backgroundColor");
    t.className = 'color2_light';
    Salud.Applications.UI.Skin.color2_light = $(t).css("backgroundColor");
    t.className = 'color3';
    Salud.Applications.UI.Skin.color3 = $(t).css("backgroundColor");
    t.className = 'color3_light';
    Salud.Applications.UI.Skin.color3_light = $(t).css("backgroundColor");
    t.className = 'color4';
    Salud.Applications.UI.Skin.color4 = $(t).css("backgroundColor");
    t.className = 'color4_light';
    Salud.Applications.UI.Skin.color4_light = $(t).css("backgroundColor");

    Salud.Applications.UI.InitAllContents(false);
});


Salud.Applications.Shared.InitDomain = function () {
    /// <summary>
    /// Inicializa el dominio para permitir interacción entre aplicaciones de diferentes hosts (ej: wwwdev, www2, sso, etc.)
    /// </summary>
    /*
    if (typeof (Salud.Applications.Shared.initDomainCalled) == "undefined") {
    var dom = document.domain;
    var domArray = dom.split('.');
    for (var i = domArray.length - 1; i >= 0; i--) {
    try {
    var dom = '';
    for (var j = domArray.length - 1; j >= i; j--) {
    dom = (j == domArray.length - 1) ? (domArray[j]) : domArray[j] + '.' + dom;
    }
    document.domain = dom;
    break;
    } catch (E) {
    }
    }
    Salud.Applications.Shared.initDomainCalled = true;
    }
    */
}

// Inicializa el dominio cuanto antes
//Salud.Applications.Shared.InitDomain();

Salud.Applications.Shared.AdministrarTabla = function (tabla, filtro, callback) {
    /// <summary>
    /// Muestra el administrador de una tabla
    /// </summary>
    /// <param name="tabla" type="String">Indica un nombre o ID de la tabla para administrar</param>
    /// <param name="filtro" type="String" optional="true">Indica un valor de filtro</param>
    /// <param name=callback"" type="Function" optional="true">Función que se ejecuta cuando el usuario finaliza la administración</param>
    popupOpen(Salud.Applications.Shared.BasePath + "Pages/AdministrarTablas.aspx?inside=1&tabla=" + tabla + "&filtro=" + ((filtro) ? filtro : ""), 600, 500, callback);
}

Salud.Applications.Shared.NormalizeString = function (text) {
    /// <summary>
    /// Elimina acentos y caracteres en español para lograr comparaciones de texto accent-insensitive
    /// </summary>
    var changes = [
                { 'base': 'A', 'letters': /[\u0041\u24B6\uFF21\u00C0\u00C1\u00C2\u1EA6\u1EA4\u1EAA\u1EA8\u00C3\u0100\u0102\u1EB0\u1EAE\u1EB4\u1EB2\u0226\u01E0\u00C4\u01DE\u1EA2\u00C5\u01FA\u01CD\u0200\u0202\u1EA0\u1EAC\u1EB6\u1E00\u0104\u023A\u2C6F]/g },
                { 'base': 'E', 'letters': /[\u0045\u24BA\uFF25\u00C8\u00C9\u00CA\u1EC0\u1EBE\u1EC4\u1EC2\u1EBC\u0112\u1E14\u1E16\u0114\u0116\u00CB\u1EBA\u011A\u0204\u0206\u1EB8\u1EC6\u0228\u1E1C\u0118\u1E18\u1E1A\u0190\u018E]/g },
                { 'base': 'I', 'letters': /[\u0049\u24BE\uFF29\u00CC\u00CD\u00CE\u0128\u012A\u012C\u0130\u00CF\u1E2E\u1EC8\u01CF\u0208\u020A\u1ECA\u012E\u1E2C\u0197]/g },
                { 'base': 'O', 'letters': /[\u004F\u24C4\uFF2F\u00D2\u00D3\u00D4\u1ED2\u1ED0\u1ED6\u1ED4\u00D5\u1E4C\u022C\u1E4E\u014C\u1E50\u1E52\u014E\u022E\u0230\u00D6\u022A\u1ECE\u0150\u01D1\u020C\u020E\u01A0\u1EDC\u1EDA\u1EE0\u1EDE\u1EE2\u1ECC\u1ED8\u01EA\u01EC\u00D8\u01FE\u0186\u019F\uA74A\uA74C]/g },
                { 'base': 'U', 'letters': /[\u0055\u24CA\uFF35\u00D9\u00DA\u00DB\u0168\u1E78\u016A\u1E7A\u016C\u00DC\u01DB\u01D7\u01D5\u01D9\u1EE6\u016E\u0170\u01D3\u0214\u0216\u01AF\u1EEA\u1EE8\u1EEE\u1EEC\u1EF0\u1EE4\u1E72\u0172\u1E76\u1E74\u0244]/g },
                { 'base': 'a', 'letters': /[\u0061\u24D0\uFF41\u1E9A\u00E0\u00E1\u00E2\u1EA7\u1EA5\u1EAB\u1EA9\u00E3\u0101\u0103\u1EB1\u1EAF\u1EB5\u1EB3\u0227\u01E1\u00E4\u01DF\u1EA3\u00E5\u01FB\u01CE\u0201\u0203\u1EA1\u1EAD\u1EB7\u1E01\u0105\u2C65\u0250]/g },
                { 'base': 'e', 'letters': /[\u0065\u24D4\uFF45\u00E8\u00E9\u00EA\u1EC1\u1EBF\u1EC5\u1EC3\u1EBD\u0113\u1E15\u1E17\u0115\u0117\u00EB\u1EBB\u011B\u0205\u0207\u1EB9\u1EC7\u0229\u1E1D\u0119\u1E19\u1E1B\u0247\u025B\u01DD]/g },
                { 'base': 'i', 'letters': /[\u0069\u24D8\uFF49\u00EC\u00ED\u00EE\u0129\u012B\u012D\u00EF\u1E2F\u1EC9\u01D0\u0209\u020B\u1ECB\u012F\u1E2D\u0268\u0131]/g },
                { 'base': 'o', 'letters': /[\u006F\u24DE\uFF4F\u00F2\u00F3\u00F4\u1ED3\u1ED1\u1ED7\u1ED5\u00F5\u1E4D\u022D\u1E4F\u014D\u1E51\u1E53\u014F\u022F\u0231\u00F6\u022B\u1ECF\u0151\u01D2\u020D\u020F\u01A1\u1EDD\u1EDB\u1EE1\u1EDF\u1EE3\u1ECD\u1ED9\u01EB\u01ED\u00F8\u01FF\u0254\uA74B\uA74D\u0275]/g },
                { 'base': 'u', 'letters': /[\u0075\u24E4\uFF55\u00F9\u00FA\u00FB\u0169\u1E79\u016B\u1E7B\u016D\u00FC\u01DC\u01D8\u01D6\u01DA\u1EE7\u016F\u0171\u01D4\u0215\u0217\u01B0\u1EEB\u1EE9\u1EEF\u1EED\u1EF1\u1EE5\u1E73\u0173\u1E77\u1E75\u0289]/g },
            ];

    for (var j = 0; j < changes.length; j++)
        text = text.replace(changes[j].letters, changes[j].base);

    return text;
}

Salud.Applications.Shared.FixAjaxify = function () {
    /// <summary>
    /// .Net tiene un bug con los componentes que utilizan ClientIDMode = Static. Esta función es llamada automáticamente por el BasePage.
    /// </summary>

    if (window._fixAjaxify)
        return;

    window._fixAjaxify = true;
    var old_uniqueIDToClientID = Sys.WebForms.PageRequestManager.prototype._uniqueIDToClientID;
    Sys.WebForms.PageRequestManager.prototype._uniqueIDToClientID = function (arg) {
        var element = this._form.elements[arg];
        return (element) ? element.id : old_uniqueIDToClientID(arg)
    }
}


Salud.Applications.UI.InitContent = function (htmlElement) {
    /// <summary>
    /// Prepara elementos visuales del elemento
    /// </summary>

    // 1. Prepara tooltips sólo si está disponible la librería QTIP
    var elements = null;
    if (!htmlElement)
        elements = $("[title]"); // = Todo la página
    else {
        if ($(htmlElement).attr("title"))
            elements = $("[title]", htmlElement).add(htmlElement);
        else
            elements = $("[title]", htmlElement);
    }

    if (elements.tipTip != undefined) {
        elements.each(function () {
            // Establece un cursor de ayuda para aquellos que no tengan manito
            var cursor = $(this).css("cursor");
            if (cursor != 'hand' && cursor != 'pointer') {
                $(this).css("cursor", "help");
            }

            // Eliminar los tooltips molestos
            if ($(this).attr("title") && ($(this).attr("title").toLowerCase().indexOf("rich text editor") == 0))
                $(this).attr("title", "");
        });

        // Inicializa
        elements.tipTip({ maxWidth: '500px' });
    }

    // 2. Aplica tweaks que CSS3 no puede manejar
    $(".buttonBox.fixed").prev().addClass("buttonBox-fixed-spacer");
}

Salud.Applications.UI.InitAllContents = function (isAjax, ajaxSender, ajaxArgs) {
    if (!Salud.Applications.UI.InitContentsHandlers)
        Salud.Applications.UI.InitContentsHandlers = [];

    // Si no es Ajax, inicializa toda la página
    if (!isAjax) {
        Salud.Applications.UI.InitContent();
    }
    else {
        // Si es Ajax, inicializa los elementos dinámicos
        var settings = ajaxSender.get_ajaxSettings();
        for (var i = 0; i < settings.length; i++) {
            var setting = settings[i];
            for (var k = 0; k < setting.UpdatedControls.length; k++) {
                var updatedControl = $get(setting.UpdatedControls[k].ControlID);
                Salud.Applications.UI.InitContent(updatedControl);
            }
        }
    }

    for (var i = 0; i < Salud.Applications.UI.InitContentsHandlers.length; i++) {
        // Si es una función ....
        if (typeof (Salud.Applications.UI.InitContentsHandlers[i]) == "function") {
            Salud.Applications.UI.InitContentsHandlers[i](isAjax, ajaxSender, ajaxArgs);
        }
        else // Es un elemento ...
        {
            Salud.Applications.UI.InitContent(Salud.Applications.UI.InitContentsHandlers[i]);
        };
    }
}

Salud.Applications.UI.AddInitContents = function (htmlElementOrFunction) {
    /// <summary>
    /// Inicializa elementos visuales cuando finaliza la carga de la página y cada vez que finaliza un requerimiento AJAX.
    /// La página debe llamar a esta función una sola vez.
    /// </summary>
    /// <param name="htmlElementOrFunction" type="Object | Function" optional="true">Elemento HTML o función que será llamada cada vez que necesita inicializarse los contenidos. Signatura: callback(isAjax, ajaxSender, ajaxArgs)</param>

    if (!Salud.Applications.UI.InitContentsHandlers)
        Salud.Applications.UI.InitContentsHandlers = [];

    if (htmlElementOrFunction) {
        Salud.Applications.UI.InitContentsHandlers[Salud.Applications.UI.InitContentsHandlers.length] = htmlElementOrFunction;
    }
}

Salud.Applications.UI.InitBaseControl = function (controlId, postbackControlId, postbackArgumentId) {
    /// <summary>
    /// Crea el objeto de client asociado al elemento controlId
    /// </summary>
    /// <param name="controlId" type="String">ID del elemento HTML</param>

    var baseControl = $get(controlId);
    baseControl.postbackControl = $get(postbackControlId);
    baseControl.postbackArgument = $get(postbackArgumentId);
    baseControl.postback = function (argument) {
        /*
        Salud.Applications.Telerik.ShowLoadingPanel(controlId);
        Salud.Applications.Telerik.AddAjaxHandlers(null, function () {
        Salud.Applications.Telerik.HideLoadingPanel(controlId)
        });
        */
        baseControl.postbackArgument.value = (argument) ? argument : "";
        baseControl.postbackControl.click();
    };
}

Salud.Applications.UI.Avatar.Initialize = function () {
    /// <summary>
    /// Inicializa el avatar y su menú contextual. Esta función es llamada por el MasterPage
    /// </summary>

    // Información de sesión
    var $container = $("#SessionDiv");
    $container.append(String.format('<div class="sessionInfo"><div class="title">Sesión activa</div><div class="fullname">{0}</div></div>', Salud.Security.SSO.Session.Fullname));

    // Avatar y menú
    var $avatar = $(String.format('<div class="avatar"><img src="{0}/FileHandler.ashx?tbl=1&idRegistro={1}" /></div>', Salud.Applications.Shared.IntranetPath, Salud.Security.SSO.Session.UserId)).appendTo($container);
    var items = [
            {
                text: "Bloquear sesión",
                url: "javascript:Salud.Security.SSO.LockSession()",
                imageUrl: "/Resources.Net/Iconos/seguridad.png"
            },
            {
                text: "Cerrar sesión",
                url: Salud.Security.SSO.BasePath + "/Logout.aspx",
                imageUrl: "/Resources.Net/Iconos/cancelar.png"
            },
            {
                text: "Cambiar de usuario",
                url: Salud.Security.SSO.BasePath + "/Logout.aspx?relogin=1&url=" + escape(window.location),
                imageUrl: "/Resources.Net/Iconos/actualizar.png"
            },
            {
                text: "Opciones de usuario",
                url: "javascript:Salud.Security.SSO.ShowOptions()",
                imageUrl: "/Resources.Net/Iconos/especial.png"
            },
            {
                text: "<hr />",
                encoded: false
            },
            {
                text: "Tema visual: Tierra",
                url: "javascript:Salud.Applications.UI.ChangeTheme(\"Tierra\")",
                imageUrl: Salud.Applications.Shared.ThemesPath + "/Tierra/icon.jpg"
            },
            {
                text: "Tema visual: Sol",
                url: "javascript:Salud.Applications.UI.ChangeTheme(\"Sol\")",
                imageUrl: Salud.Applications.Shared.ThemesPath + "/Sol/icon.jpg"
            }
        ];

    if (Salud.Security.SSO.Session.GlobalAdmin || Salud.Security.SSO.Session.AppAdmin) {
        items.splice(4, 0, {
            text: "<hr />",
            encoded: false
        });

        items.splice(5, 0, {
            text: "Administrar usuarios",
            url: "/scripts/sso/ssoadmin.dll/administrationBasic",
            imageUrl: "/Resources.Net/Iconos/seguridad.png"
        });

        if (Salud.Security.SSO.Session.GlobalAdmin)
            items.splice(6, 0, {
                text: "Enviar notificaciones",
                url: "javascript:Salud.Security.SSO.Messages.SendMessage()",
                imageUrl: "/Resources.Net/Iconos/email.png"
            });
    }

    $avatar.PlexMenu({ items: items });
}

Salud.Applications.UI.Menu.Initialize = function () {
    /// <summary>
    /// Inicializa el menú de aplicaciones. Esta función es llamada por el MasterPage
    /// </summary>

    Salud.Security.SSO.GetApplicationMenu(function (menu) {
        if (menu) {
            var $applicationMenu = $("#applicationMenu").prepend('<li><a href="/">Intranet</a></li><li><a>Aplicaciones</a><ul></ul></li>');
            var $container = $applicationMenu.children().eq(1).find("UL"); /* Item "Aplicaciones" */
            $.each(menu, function () {
                var $li = $(String.format("<LI id='am-application{0}'>", this.id));
                $li.data("menuData", this); // Guarda datos para futura referencia

                if (this.id == Salud.Security.SSO.Session.ApplicationId)
                    $li.addClass("selected").prependTo($applicationMenu);
                else
                    $li.appendTo($container);

                var $a = $("<A>").html(this.text).appendTo($li);
                $("<IMG>").attr("src", '/Resources.Net/iconos/aplicaciones/' + this.id + '.png').prependTo($a);
                var applicationURL = this.url;

                // Función para ser llamada recursivamente
                var initItems = function ($container, items) {
                    if (items.length) {
                        var $ul = $("<UL>").appendTo($container);
                        $.each(items, function () {
                            var $li = $("<LI>").appendTo($ul);
                            if (this.isSeparator) {
                                $li.addClass("separator");
                            } else {
                                var $a = $("<A>").html(this.text).attr("href", this.url ? applicationURL + this.url : null).appendTo($li);
                                if (this.imageURL)
                                    $("<IMG>").attr("src", this.imageURL).prependTo($a);
                            }
                            initItems($li, this.items);
                        });
                    };
                }

                // Items
                initItems($li, this.items);
            });
        }
    });
}

Salud.Applications.UI.Menu.Add = function (options) {
    /// <summary>
    /// Permite agregar dinámicamente items
    /// <param name="options" type="json">Una o más de las siguientes opciones
    ///     applicationId (opcional): Indica un ID de aplicación para agregar como subitem item
    ///     applicationText (opcional): Indica un texto de aplicación para buscar y agregar como subitem
    ///     text (opcional): Texto del item
    ///     isSeparator (opcional): Indica si es un separador
    ///     url (opcional): URL del item
    ///     imageURL (opcional): imagen del item
    /// </param>
    /// </summary>

    var $ul;
    if (options.applicationId) {
        var $app = $(String.format("#am-application{0}", applicationId));
        $ul = $app.children("UL");
        options.url = options.url ? $app.data("menuData").url + options.url : null;
    } else
        if (options.applicationText) {
            var $app = $("#applicationMenu").children(String.format(":contains('{0}')", options.applicationText));
            $ul = $app.children("UL");
            if (!$ul.length)
                $ul = $("<UL>").appendTo($app);
        }
        else {
            // Lo agrega en la raiz
            var $ul = $("#applicationMenu");
            //var $container = $applicationMenu.children().eq(0); /* Item "Intranet" */
        }

    var $li = $("<LI>").appendTo($ul);
    if (options.isSeparator) {
        $li.addClass("separator");
    }
    else {
        var $a = $("<A>").html(options.text).attr("href", options.url).appendTo($li);
        if (options.imageURL)
            $("<IMG>").attr("src", options.imageURL).prependTo($a);
    }
}

Salud.Applications.UI.MostrarMensajes = function (mensajes) {
    /// <summary>
    /// Muestra un pop-up con mensajes para el usuario
    /// </summary>
    /// <param name="mensajes" type="Array">Array de objetos JSON
    /// {
    ///     tipo: String con uno de los siguientes valores: normal, advertencia, error
    ///     mensaje: String
    /// } 
    /// </param>

    var $list = $("<div>");
    $(mensajes).each(function () {
        $item = $("<div>").appendTo($list);
        switch (this.tipoString) {
            case "advertencia":
                $("<div>").addClass("warningBox").html(this.texto).appendTo($item);
                break;
            case "error":
                $("<div>").addClass("errorBox").html(this.texto).appendTo($item);
                break;
            default:
                $("<div>").addClass("infoBox").html(this.texto).appendTo($item);
                break;
        }
    });

    popupAlert($list);
}

Salud.Applications.UI.ChangeTheme = function (theme) {
    var html = '<div><h3 style="white-space: nowrap">¡El tema fue cambiado exitosamente!</h3><h4>Hacé clic en el botón para actualizar la página</h4><br/><button class="botoncitoActualizar">Actualizar la página</button></div>';
    $(html).PlexDialog({
        title: 'Cambiar tema',
        open: function (sender) {
            var container = $(sender.target);
            $("BUTTON", container).Plex().click(function () {
                window.location.reload();
            });

            container.PlexLoading();
            $.ajax({
                url: Salud.Applications.Shared.BasePath + "/Services/Common.asmx/Theme",
                data: { id: theme },
                success: function (msg) {
                    container.PlexLoading();
                },
                error: function (msg) {
                    container.PlexLoading();
                }
            });
        }
    });
}

Salud.Applications.UI.ShowFeedback = function (options) {
    /// <summary>
    /// Muestra un formulario para enviar un mensaje de sugerencia
    /// </summary>
    /// <param name="options" type="JSON">Objeto JSON con una o más opciones
    ///     recipient (requerido): String indicado el destino. Debe ser un tipo conocido.
    ///     subject (opcional): Asunto del feedback
    ///     title (opcional): Titulo de la ventana
    ///     caption (opcional): Texto con las indicaciones para el usuario
    /// </param>

    options = $.extend({
        title: "Enviar un mensaje",
        subject: "Feedback",
        caption: "Ingresa a continuación tu mensaje o sugerencia.<br />A la brevedad se pondrán en contacto contigo."
    }, options);

    var html = '<div><h3 style="white-space: nowrap">' + options.caption + '<br /><textarea style="width: 90%; height: 100px"></textarea><br /><div style="margin: 10px 0px 0px -5px"><button class="botoncitoEmail">Enviar mensaje</button></div></div>';
    $(html).PlexDialog({
        title: options.title,
        open: function (sender) {
            var container = $(sender.target);
            $("TEXTAREA", container).Plex();
            $("BUTTON", container).Plex().click(function () {
                var message = $("TEXTAREA", container).val();
                if (message.length < 5)
                    alert("Debes ingresar un mensaje");
                else {
                    container.PlexLoading();
                    $.ajax({
                        url: Salud.Applications.Shared.BasePath + "/Services/Common.asmx/Feedback",
                        data: {
                            recipient: options.recipient,
                            subject: options.subject,
                            message: message,
                            context: window.location.toString()
                        },
                        success: function (msg) {
                            container.PlexLoading();
                            alert("¡El mensaje fue enviado correctamente!");
                            container.PlexDialog("close");
                        },
                        error: function (msg) {
                            container.PlexLoading();
                            alert("El mensaje no pudo ser enviado. Intente nuevamente.");
                        }
                    });
                }
            });
        }
    });
}

Salud.Applications.UI.Search.AddHandler = function (options) {
    /// <summary>
    /// Registra un Web Service que devuelve resultados de la búsqueda
    /// </summary>    

    // Default options
    options = jQuery.extend({
        name: null,
        searchService: null, /* Webservice que devuelve los resultados de la búsqueda. Parámetros: [string context, string text, string tags] */
        supportsTags: false,
        highlightTitle: true,
        highlightText: true
    }, options);

    if (!Salud.Applications.UI.Search.Handlers)
        Salud.Applications.UI.Search.Handlers = [];
    Salud.Applications.UI.Search.Handlers[Salud.Applications.UI.Search.Handlers.length] = options;
}


Salud.Applications.UI.Search.SearchBox = function (container, options) {
    /// <summary>
    /// Inicializa un nuevo componente de búsqueda en el contenedor especificado, el cual debe tener la siguiente estructura:
    ///    <div class="searchBox">
    ///      <input type="text" />
    ///      <button></button>
    ///      <div class="resultHolder"></div>
    ///    </div>
    /// </summary>    

    this.container = $(container);
    this.input = $("INPUT", this.container);
    this.tabStrip = null; // Mnatiene una referencia al TabStrip de los resultados
    this.resultHolder = $(".resultHolder", this.container);
    this.tags = [];
    this.tagNames = [];
    this.resultCount = 0;
    this.resultCache = [];
    this.historyApiID = "SEARCHBOX_UNIQUEID" /* Si en un futuro hay multiples search boxes que soporten History.API debe tener un ID único */;
    this.options = jQuery.extend({
        useHistoryApi: false, // Indica si utiliza History.Api
        hideResults: false, // Indica si oculta automáticamente los resultados cuando se hace un clic en el documento
        searchHandler: null, // Si no se especifica ningún handler utiliza los handlers globales (i.e. Salud.Applications.UI.Search.Handlers)
        searchOnChange: false, // Busca automáticamente cuando el textbox cambia (aún sin perder el focus)
        noResultsCaption: "La búsqueda no arrojó resultados",
        onStart: null, // Callback que se ejecuta cuando inicia la búsqueda
        onComplete: null // Callback que se ejecuta cuando finalizan todos los handlers
    }, options);

    this.Reset = function (clearInput) {
        this.resultCount = 0;
        this.resultCache = [];
        this.tags = [];
        this.tagNames = [];
        if (clearInput)
            this.input.val("");
    }

    this.StopTimer = function () {
        if (Salud.Applications.UI.Search.TimerId) {
            window.clearTimeout(Salud.Applications.UI.Search.TimerId);
            Salud.Applications.UI.Search.TimerId = null;
        }
    }

    this.AddTag = function (id, name) {
        this.tags.push(id);
        this.tagNames.push(name);
        this.DoSearch();
    }

    this.Highlight = function (text, words) {
        for (var i = 0; i < words.length; i++)
            if (words[i] && (words[i] != 'span') && (words[i] != 'clas') && (words[i] != 'match')) {
                var nText = Salud.Applications.Shared.NormalizeString(text.toLowerCase());
                var j = nText.indexOf(words[i]);
                if (j >= 0)
                    text = text.substr(0, j) + '<span class=match>' + text.substr(j, words[i].length) + '</span>' + text.substr(j + words[i].length);
            }

        return text;
    }

    this.GetContainer = function (name, resultCount) {
        if (resultCount > 0) {
            (this.tabStrip.element).show();
            // Crea el tab
            this.tabStrip.append({
                text: String.format("{0} (<b>{1}</b> coincidencias)", name, resultCount),
                encoded: false,
                content: "&nbsp;"
            });

            // Selecciona el primer tab
            if (this.tabStrip.select().length == 0)
                this.tabStrip.select(this.tabStrip.contentElements.length - 1);
            return this.tabStrip.contentElements.last();
        } else {
            return null;
        }
    }

    this.ResetResults = function () {
        var self = this;
        this.resultCount = 0;
        this.resultHolder.empty();

        // Hide results
        this.clickHandler = function (e) {
            if (!self.resultHolder.has(e.target).length) {
                $(document).unbind('click', self.clickHandler);
                self.resultHolder.hide();
            }
        }
        if (self.options.hideResults)
            $(document).unbind('click', self.clickHandler).bind('click', self.clickHandler);

        // Tabstrip
        this.tabStrip = $("<DIV>").append($("<ul>")).appendTo(this.resultHolder).hide().kendoTabStrip({ animation: false }).data("kendoTabStrip");
    }

    this.DisplayResults = function (handlerName, highlightTitle, highlightText, data, searchWords) {
        var self = this;
        var container = self.GetContainer(handlerName, data.length);
        $(data).each(function () {
            // Highlight matches                            
            var originalTitle = this.title;
            var originalText = this.text;
            if (highlightTitle && this.title)
                this.title = self.Highlight(this.title, searchWords);
            if (highlightText && this.text)
                this.text = self.Highlight(this.text, searchWords);

            // Prepara tags
            var tagArray = null;
            if (this.tags && this.tags.length > 0) {
                tagArray = [];
                $(this.tags).each(function () {
                    // Highlight
                    var matchedClass = "";
                    // ... si buscó por tag
                    for (var i = 0; i < self.tags.length; i++)
                        if (this.id == self.tags[i]) {
                            matchedClass = "matched";
                            break;
                        }
                    // ... si buscó por texto
                    var tag = Salud.Applications.Shared.NormalizeString(this.nombre.toLowerCase());
                    for (var i = 0; i < searchWords.length; i++)
                        if (tag.indexOf(searchWords[i]) >= 0) {
                            matchedClass = "matched";
                            break;
                        }

                    // Crea el tag
                    tagArray.push(
                        $('<span title="Hacé clic aquí para buscar páginas que contengan este tag" />').html(this.nombre)
                        .addClass("relatedTag " + matchedClass)
                        .data("idTag", this.id)
                        .bind("click", function (event) {
                            self.Reset(true);
                            self.AddTag($(this).data("idTag"), $(this).html());
                            return false;
                        })[0]
                    );
                });
            }

            var template = '<TR onclick="window.location=\'${url}\'"><TD><div class="pictureBox">\
                                <img src="${image}" />\
                            </div></TD>\
                            <TD><div class="text">\
                                {{if title}}\
                                    <b>{{html title}}</b><br/>\
                                {{/if}}\
                                {{html text}}\
                            </div>\
                            {{if tags}}\
                                <div class="relatedTags"></div>\
                            {{/if}}\
                            </TD></TR>';
            var div = $("<TABLE/>").addClass("result").html($.tmpl(template, this));
            if (tagArray)
                $(".relatedTags", div).append(tagArray);
            container.append(div);
            Salud.Applications.UI.InitContent(div);

            // Finalization
            this.title = originalTitle;
            this.text = originalText;
        });
    }

    this.DoStart = function () {
        if (this.options.onStart)
            this.options.onStart(this);
    }

    this.DoFinish = function (saveCache) {
        var finishedLoading = true;
        for (var j = 0; j < Salud.Applications.UI.Search.Handlers.length; j++)
            if (Salud.Applications.UI.Search.Handlers[j].ajaxRequest) {
                finishedLoading = false;
                break;
            }

        if (finishedLoading) {
            // UI
            $(".loading", this.resultHolder).remove();
            if (this.resultCount == 0)
                $(".count", this.resultHolder).addClass("noResults").html(this.options.noResultsCaption);
            //else $(".count", this.resultHolder).html(String.format("Se encontraron <b>{0}</b> resultado(s)", this.resultCount));

            // History.Api
            if (saveCache) {
                history.replaceState({
                    id: this.historyApiID,
                    data: {
                        text: this.input.val().trim(),
                        tags: this.tags,
                        data: this.resultCache,
                        resultCount: this.resultCount
                    }
                }, null, "#search");
            }

            // Dispara eventos
            if (this.options.onComplete)
                this.options.onComplete(this, this.input.val().trim(), this.tagNames);
        }
    }

    this.DoSearch = function (searchCache) {
        /// <summary>
        /// Inicia la búsqueda. Si se especifica el objeto searchCache muestra los datos almacenados (utilizado en conjunto con History Api)
        /// <param name="searchCache" type="object">
        /// Un objeto JSON {text, tags, data}
        /// </param>
        /// </summary>    
        var self = this;

        if (!searchCache && (!Salud.Applications.UI.Search.Handlers || Salud.Applications.UI.Search.Handlers.length == 0))
            return;

        // Reset results
        self.StopTimer();
        self.ResetResults();

        // Abortar todos los handlers si hay una búsqueda en curso
        for (var i = 0; i < Salud.Applications.UI.Search.Handlers.length; i++)
            if (Salud.Applications.UI.Search.Handlers[i].ajaxRequest) {
                Salud.Applications.UI.Search.Handlers[i].ajaxRequest.abort();
                Salud.Applications.UI.Search.Handlers[i].ajaxRequest = null;
            }

        // Obtiene datos del caché
        if (searchCache) {
            self.input.val(searchCache.text);
            self.tags = searchCache.tags;
            self.resultCount = searchCache.resultCount;
        }

        // ¿Debe buscar?
        var text = self.input.val().trim();
        if (text || self.tags.length > 0) {
            self.DoStart();

            // UI
            self.resultHolder.fadeIn();
            self.resultHolder.append('<div class="loading"></div>');
            self.resultHolder.append('<div class="count"></div>');

            // Encuentra las palabras de búsqueda
            var searchWords = (text) ? text.replace('"', '').split(new RegExp("[<>/,\:;' ]+")) : [];
            var last = searchWords.length;
            for (var i = 0; i < last; i++) {
                searchWords[i] = Salud.Applications.Shared.NormalizeString(searchWords[i].toLowerCase());
                // Si la palabra está en plural, agrega el singular
                // ... ES
                var index = searchWords[i].indexOf("es", searchWords[i].length - 2);
                if (index >= 0)
                    searchWords.push(searchWords[i].substr(0, searchWords[i].length - 2));
                // ... S
                index = searchWords[i].indexOf("s", searchWords[i].length - 1);
                if (index >= 0)
                    searchWords.push(searchWords[i].substr(0, searchWords[i].length - 1));
            }

            // ¿Mostrar desde caché?
            if (searchCache) {
                $(searchCache.data).each(function () {
                    self.DisplayResults(this.handlerName, this.highlightTitle, this.highlightText, this.resultData, searchWords);
                });
                self.DoFinish(false);
            }
            else {
                // Realiza la búsqueda
                for (var i = 0; i < Salud.Applications.UI.Search.Handlers.length; i++) {
                    var handler = Salud.Applications.UI.Search.Handlers[i];
                    var params;
                    if (handler.supportsTags)
                        params = { context: window.location.toString(), text: text, tags: self.tags.join() };
                    else
                        params = { context: window.location.toString(), text: text };

                    if (text || (!text && handler.supportsTags))
                        Salud.Applications.UI.Search.Handlers[i].ajaxRequest = $.ajax({
                            type: "POST",
                            url: Salud.Applications.UI.Search.Handlers[i].searchService,
                            data: JSON.stringify(params),
                            processData: false,
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (data, textStatus, jqXHR) {
                                // Busca el handler y lo marca como finalizado
                                var handler;
                                for (var j = 0; j < Salud.Applications.UI.Search.Handlers.length; j++)
                                    if (Salud.Applications.UI.Search.Handlers[j].ajaxRequest == jqXHR) {
                                        Salud.Applications.UI.Search.Handlers[j].ajaxRequest = null;
                                        handler = Salud.Applications.UI.Search.Handlers[j];
                                        break;
                                    }

                                // Muestra los resultados
                                self.resultCount += data.d.length;
                                if (data.d) {
                                    self.resultCache.push({
                                        handlerName: handler.name,
                                        highlightTitle: handler.highlightTitle,
                                        highlightText: handler.highlightText,
                                        resultData: data.d
                                    });
                                    self.DisplayResults(handler.name, handler.highlightTitle, handler.highlightText, data.d, searchWords);
                                }
                                // Finaliza
                                self.DoFinish(self.options.useHistoryApi);
                            },
                            error: function (jqXHR, textStatus, errorThrown) {
                                if (textStatus.toLowerCase() != "abort")
                                    alert("La búsqueda no pudo completarse. Actualice la página e intente la operación nuevamente");
                            }
                        });
                }
            }
        }
        else
            self.resultHolder.fadeOut();
    }

    this.LoadHistoryData = function () {
        var stateData = History.getState().data;
        if (stateData && stateData.id == this.historyApiID) {
            this.DoSearch(stateData.data);
        }
    }

    this.Initialization = function () {
        var self = this;

        if (self.options.useHistoryApi) {
            $(window).bind('popstate', function () {
                self.LoadHistoryData();
            });
        }

        $("BUTTON", this.container).bind('click', function (event) {
            self.StopTimer();
            if (self.input.val().trim())
                self.DoSearch();
        });

        self.input.bind('focus', function () {
            self.Reset(false);
        });

        self.input.bind('keypress', function (event) {
            self.StopTimer();
            if (event.keyCode == 13) {
                self.input.autocomplete("close");
                self.DoSearch();
                event.preventDefault();
                return false;
            } else {
                if (self.options.searchOnChange && ((event.which !== 0 && event.charCode !== 0) || (event.keyCode == 8 || event.keyCode == 46) && ($(self.input).val().length > 0)))
                    Salud.Applications.UI.Search.TimerId = window.setTimeout(function () { self.DoSearch(); }, 500);
            }
        });
    }

    this.Initialization();
}


Salud.Applications.prepareDebuggingURL = function (url) {
    /// <summary>
    /// Prepara un url de aplicaciones legacy (i.e. Delphi) mientras se hace debugging
    /// </summary>
    if (!top.window.isDebugging) {
        return url
    } else {
        return debuggingServer + url;
    }
}

////////////////////////////////////////////
// Popup functions
////////////////////////////////////////////

function popupAlert(message) {
    try {
        window.top.$.PlexAlert(message);
    } catch (E) {
        $.PlexAlert(message);
    }
}

function popupOpen(url, width, height, onCloseCallBack) {
    /// <summary>
    /// [Obsolete] Muestra un popup utilizando Telerik. Utilizar popupShow() que funciona con Plex!
    /// </summary>
    return popupOpenEx(url, width, height, onCloseCallBack, true, Telerik.Web.UI.WindowBehaviors.Move + Telerik.Web.UI.WindowBehaviors.Close);
}

function popupOpenEx(url, width, height, onCloseCallBack, isModal, behaviours, isCentered) {
    /// <summary>
    /// [Obsolete] Muestra un popup utilizando Telerik. Utilizar popupShow() que funciona con Plex!
    /// </summary>

    // Valores por default
    if (typeof (isCentered) == 'undefined')
        isCentered = true;

    // Cierra cualquier RadContextMenu abierto    
    Salud.Applications.Telerik.closeContextMenu();

    // Inicializa el evento para recentrar la ventana
    if (!document.extension_OnScrollEvent) {
        document.extension_OnScrollEvent = true;
        $(document).scroll(function () {
            var oWindow = Salud.Applications.Telerik.GetRadWindow();
            if (oWindow && oWindow.extension_IsCentered) oWindow.center();
        });
    }

    // 27/01/2012 | jgabriel | Corregí un bug cuando se abren ventanas dentro de otras ventanas con diferentes URL base
    var loc = location.href;
    var dir = loc.substring(0, loc.lastIndexOf('/'));
    url = (url.toLowerCase().indexOf('http:') == 0 || url.toLowerCase().indexOf('https:') == 0) || (url.indexOf("/") == 0) ? url : dir + '/' + ((url.indexOf('/') == 0) ? url.substring(1) : url);

    var oWindow = top.window.radopen(url, null);

    if ((width == 0) || (height == 0) || (width == null) || (height == null)) {
        oWindow.add_pageLoad(function () { oWindow.autoSize(); if (isCentered) oWindow.center(); });
        // oWindow.autoSize(true) = anima el resize, pero el problema es que el center() posterior no se ejecuta correctamente
        oWindow.extension_IsAutosize = true;
        oWindow.extension_IsCentered = isCentered;
    } else {
        oWindow.setSize(width, height);
    }

    oWindow.set_behaviors(behaviours);
    window.setTimeout(function () { oWindow.set_modal(isModal); oWindow.setActive(true) }, 0);
    //oWindow.set_modal(isModal);
    //window.setTimeout(function () { oWindow.setActive(true) }, 100);
    if (onCloseCallBack)
        oWindow.add_close(onCloseCallBack);

    return oWindow;
}

function popupShow(url, options) {
    /// <summary>
    /// Muestra un popup utilizando $.PlexDialog con opciones comunes
    /// <param name="url" type="String">URL de la página a mostrar</param>
    /// <param name="options" type="Function | JSON">Puede ser una función de callback o bien un objeto JSON con una o más opciones
    ///     close (opcional): callback que recibirá el parámetro enviado en popupHide()
    ///     width (opcional) /* NO IMPLEMENTADO */: ancho del iframe que contenerá la página
    ///     height (opcional) /* NO IMPLEMENTADO */: ancho del iframe que contenerá la página
    ///     title (opcional): Título del popup. Si no se especifica se tomará el título de la página cargada en el iframe
    /// </summary>

    if (options) {
        var callback = jQuery.isFunction(options) ? options : options.close;
        if (callback) {
            options.close = function (e) {
                var $this = window.top.$(e.target);
                var data = $this.data("dialogReturnValue");
                $this.dialog("destroy");
                $this.remove();
                // El setTimeout soluciona el problema cuando se abre otro dialog en el callback
                window.setTimeout(function () { callback(data) }, 50);
            }
        }
    }
    options = $.extend({
        close: function () {
            var $this = window.top.$(this);
            $this.dialog("destroy");
            $this.remove();
        }
    }, options);

    var loc = location.href;
    var dir = loc.substring(0, loc.lastIndexOf('/'));
    url = (url.toLowerCase().indexOf('http:') == 0 || url.toLowerCase().indexOf('https:') == 0) || (url.indexOf("/") == 0) ? url : dir + '/' + ((url.indexOf('/') == 0) ? url.substring(1) : url);

    var $iframe = window.top.$.PlexDialog(url, options);
    $iframe.data("dialogReturnValue", null);
    return $iframe;
}

function popupClose(returnValue, handle) {
    /// <summary>
    /// Oculta un popup abierto con popupOpen o popShow.
    /// <param name="returnValue">Parámetro que será devuelto al callback</param>
    /// <param name="handle">Cierra la ventana indicada. Este valor es devuelto por popupShow()</param>
    /// </summary>

    /* Cuando no se utilice más popOpen borrar estas líneas de Telerik */
    var oWindow = Salud.Applications.Telerik.GetRadWindow();
    if (oWindow) {
        oWindow.close(returnValue);
        return true;
    } else {
        if (handle) {
            var $iframe = $(handle)
            $iframe.data("dialogReturnValue", returnValue);
            $iframe.PlexDialog('close');
            return true;
        }
        else
            if (window.frameElement) {
                var $iframe = window.top.$(window.frameElement)
                $iframe.data("dialogReturnValue", returnValue);
                $iframe.PlexDialog('close');
                return true;
            }
            else
                return false;
    }
}
