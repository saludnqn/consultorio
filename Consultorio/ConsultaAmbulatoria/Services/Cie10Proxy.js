ServiceProxy = function() //constructor for the proxy
{
    this._baseURL = "ConsultaAmbulatoria/Services/Cie10.asmx/";
};

ServiceProxy.prototype =
{
    _defaultErrorHandler: function(xhr, status, error) {
        alert(xhr.statusText);
    },

    _doAjax: function(method, data, fnSuccess, fnError) {
        if (!data) data = {};

        if (!fnError) fnError = this._defaultErrorHandler;

        $.ajax({
            type: "GET",
            url: this._baseURL + method,
            data: data,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: fnSuccess,
            error: fnError,
            dataFilter: function(data) {
                var response;

                if (typeof (JSON) !== "undefined" && typeof (JSON.parse) === "function")
                    response = JSON.parse(data);
                else
                    response = val("(" + data + ")");

                if (response.hasOwnProperty("d"))
                    return response.d;
                else
                    return response;
            }
        });
    },
    getCie10: function(codigo, success, error) {
        var data = { codigo: codigo };

        this._doAjax("getCie10", data, success, error)
    },
    buscarCie10: function(cadena, success, error) {
        var data = { cadena: cadena };

        this._doAjax("buscarCie10", data, success, error)
    }
};
