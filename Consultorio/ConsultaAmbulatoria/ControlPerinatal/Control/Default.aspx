 <%@ Page Title="" Language="C#" MasterPageFile="~/ConsultaAmbulatoria/MasterPages/ConsultorioPerinatal.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Consultorio.ConsultaAmbulatoria.ControlPerinatal.Control.Default" Theme="apr" %>

<%@ MasterType VirtualPath="~/ConsultaAmbulatoria/MasterPages/ConsultorioPerinatal.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="Stylesheet" type="text/css" href="../css/cperinatal.css" />
    <link rel="Stylesheet" type="text/css" href="../css/cperinatalextra.css" />
    <link rel="Stylesheet" type="text/css" href="../css/cperinataldetalles.css" />
    <link rel="Stylesheet" type="text/css" href="../css/alertBox.css" />
    <script src="../js/bootstrap.min.js"></script>




    <%--<script type="text/javascript" src="../js/date.js"></script>--%>

    <%--<script type="text/javascript" src="../js/date-es-AR.js"></script>--%>

    <%--Intento de pasar a imagen--%>


    <script type="text/javascript" src="../js/html2canvas.js"></script>

    <script type="text/javascript" src="../js/moment.js"></script>


    <%--fin--%>
    <style>
       .btn-danger{
        padding: 5px !important;
        }
        .botonColor {
            padding: 6px 12px !important;
            background-color: #C1CC9E !important;
            border-color: #C1CC9E !important;
        }

        .modal-backdrop.in {
    height: 100% !important;
            }
     .modalperson {
                z-index: 99998;
                width: 940px !important;
            }
    .ui-widget-content {
                z-index: 99999 !important;
                
            }

   .botonColor {
            padding: 6px 12px !important;
            background-color: #C1CC9E !important;
            border-color: #A7AE93 !important;
            color: #000 !important;
        }
   .botonColor:hover {
            padding: 6px 12px !important;
            background-color: #C1CC9E !important;
            border-color: #C1CC9E !important;
            color: #ffffff !important;
        }

    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%= this.Form.ClientID %>").validationEngine('attach');
            var allRadios = $('input[type=radio]')
            var radioChecked;
            var setCurrent = function (e) {
                var obj = e.target;
                radioChecked = $(obj).attr('checked');
            }
            var setCheck = function (e) {
                if (e.type == 'keypress' && e.charCode != 32) {
                    return false;
                }
                var obj = e.target;
                if (radioChecked) {
                    $(obj).attr('checked', false);
                } else { $(obj).attr('checked', true); }
            }
            $.each(allRadios, function (i, val) {
                var label = $('label[for=' + $(this).attr("id") + ']');
                $(this).bind('mousedown keydown', function (e) {
                    setCurrent(e);
                });
                label.bind('mousedown keydown', function (e) {
                    e.target = $('#' + $(this).attr("for"));
                    setCurrent(e);
                });
                $(this).bind('click', function (e) {
                    setCheck(e);
                });
            });

            /*funcion deshabilita el boton guardar una vez q guardo */


<%--            $('#<%= btnGuardar.ClientID %>').live('click', function () {
                alert('Los datos se guardaron correctamente.');
                $('#<%= btnGuardar.ClientID %>').attr("disabled", true);
            });--%>


            $('input').on("keypress", function (e) {
                if (e.keyCode == 13) {
                    var inputs = $(this).parents("form").eq(0).find(":input:visible");
                    var idx = inputs.index(this);
                    if (idx == inputs.length - 1) {
                        inputs[0].select()
                    } else {
                        inputs[idx + 1].focus(); //  handles submit buttons
                        inputs[idx + 1].select();
                    }
                    return false;
                }
            });

            /* ToolTips
            $('.tootipeable').tooltip({
            position: "bottom center",
            offset: [10, -2],
            effect: 'fade',
            opacity: 0.3
            });  */
            /* Fechas de VIH */
            $('.divDatePopUp').hover(
            function () {
                //mouse enter
                $(this).animate({ width: '172px' }, { queue: false, duration: 'fast' });
                $(this).children('.txtVIHFecha').fadeIn();
            },
            function () {
                // mouse leave
                $(this).animate({ width: '65px' }, { queue: false, duration: 'fast' });
                $(this).children('.txtVIHFecha').fadeOut();
            });
            /* Fechas de Sifilis */
            /*Prueba no treponemica*/
            $('.divSifilisPNTPopUp').hover(
            function () {
                //mouse enter
                $(this).animate({ width: '174px' }, { queue: false, duration: 'fast' });
                $(this).children('.txtSifilisPNTFecha').fadeIn();
            },
            function () {
                // mouse leave
                $(this).animate({ width: '67px' }, { queue: false, duration: 'fast' });
                $(this).children('.txtSifilisPNTFecha').fadeOut();
            });
            /*Prueba treponemica*/
            $('.divSifilisPTPopUp').hover(
            function () {
                //mouse enter
                $(this).animate({ width: '181px' }, { queue: false, duration: 'fast' });
                $(this).children('.txtSifilisPTFecha').fadeIn();
            },
            function () {
                // mouse leave
                $(this).animate({ width: '74px' }, { queue: false, duration: 'fast' });
                $(this).children('.txtSifilisPTFecha').fadeOut();
            });
            /*Tratamiento*/
            $('.divSifilisTRATPopUp').hover(
            function () {
                //mouse enter
                $(this).animate({ width: '181px' }, { queue: false, duration: 'fast' });
                $(this).children('.txtSifilisTratamientoFecha').fadeIn();
            },
            function () {
                // mouse leave
                $(this).animate({ width: '74px' }, { queue: false, duration: 'fast' });
                $(this).children('.txtSifilisTratamientoFecha').fadeOut();
            });
            //Calculo fechas /*/*/*/*/*/*/*/*

            $('#<%= txtFUM.ClientID %>').change(function () {
                var fum = moment($('#<%= txtFUM.ClientID %>').val(), "DD/MM/YYYY");
                if (fum != null) {
                    var fechaControl = Date.parse($('#<%= txtDetalleFecha.ClientID %>').val());
                    var saberNaN = (isNaN(fechaControl));
                    if (saberNaN != true) {
                        var edadGestacional = moment(fechaControl).diff(fum, "weeks");        
                        $('#<%= txtDetalleEdadGestacional.ClientID %>').val(edadGestacional);
                        //calculo si es captacion oportuna
                        var primerControl = $('#<%= hfPrimerControl.ClientID %>').val();
                        if (primerControl = '1') {
                            var dias = days_between(fum, fechaControl);
                            if ((dias / 7) < 14) {
                                $('#<%= rbCaptacionOportunaAntes16Sem.ClientID %>').click();
                            } else {
                                $('#<%= rbCaptacionOportunaDespues16Sem.ClientID %>').click();
                            }
                        }
                    }
                    //debugger;
                    //alert('no entro al if');
                    //var objmoment = moment();
                    //alert(objmoment);
                    var fechaPP = moment(fum).add(40, 'weeks');
                    var formatoFecha = moment(fechaPP).format('DD/MM/YYYY');
                    $('#<%= txtFPP.ClientID %>').val(formatoFecha);
                }
            });
            $('#<%= txtDetalleFecha.ClientID %>').change(function () {  
                
                var fechaControl = moment($('#<%= txtDetalleFecha.ClientID %>').val(), "DD/MM/YYYY");
                if (fechaControl != null) {
                    var fum = moment($('#<%= txtFUM.ClientID %>').val(), "DD/MM/YYYY");
                    if (fum != null) {
                        var edadGestacional = moment(fechaControl).diff(fum, "weeks");
                        $('#<%= txtDetalleEdadGestacional.ClientID %>').val(edadGestacional);
                        //calculo si es captacion oportuna
                        var primerControl = $('#<%= hfPrimerControl.ClientID %>').val();
                        if (primerControl = '1') {
                            var dias = moment(fechaControl).diff(fum, "days");
                            if ((dias / 7) < 14) {
                                $('#<%= rbCaptacionOportunaAntes16Sem.ClientID %>').click();
                            } else {
                                $('#<%= rbCaptacionOportunaDespues16Sem.ClientID %>').click();
                            }
                        }
                    }
                }
            });

            //Embarazo Anterior menor a 1 año
            $('#<%= txtFinEmbAnterior.ClientID %>').change(function () {
                var primerControl = $('#<%= hfPrimerControl.ClientID %>').val();
                if (primerControl = '1') {
                    var finembant = Date.parse($('#<%= txtFinEmbAnterior.ClientID %>').val());
                    if (finembant != null) {
                        var fechaControl = Date.parse($('#<%= txtDetalleFecha.ClientID %>').val());
                        if (fechaControl != null) {
                            var dias = moment(finembant).diff(fechaControl, "days"); 
                            if (dias < 366) {
                                $('#<%= rbFinEmbAnteriorMenor1Año.ClientID %>').click();
                            }
                        }
                    }
                }
            });
            $('#<%= txtDetalleFecha.ClientID %>').change(function () {
                var primerControl = $('#<%= hfPrimerControl.ClientID %>').val();
                if (primerControl = '1') {
                    var finembant = Date.parse($('#<%= txtFinEmbAnterior.ClientID %>').val());
                    if (finembant != null) {
                        var fechaControl = Date.parse($('#<%= txtDetalleFecha.ClientID %>').val());
                        if (fechaControl != null) {
                            var dias = moment(finembant).diff(fechaControl);                       
                            if (dias < 366) {
                                $('#<%= rbFinEmbAnteriorMenor1Año.ClientID %>').click();
                            }
                        }
                    }
                }
            });

            //calculo IMC
            $('#<%= txtDetallePeso.ClientID %>').blur(function () {
                var peso = $('#<%= txtDetallePeso.ClientID %>').val().replace(',', '.');
                if (!isNaN(peso) && peso > 0) {
                    var talla = $('#<%= txtTalla.ClientID %>').val().replace(',', '.');
                    if (!isNaN(talla) && talla > 0) {
                        var tempimc = calculo_imc(peso, talla);
                        $('#<%= txtDetalleIMC.ClientID %>').val((+tempimc).toLocaleString());                  
                        if (tempimc > 35) {
                            addAlert('Controlar Peso.', 'imcMayor35');
                        } else {
                            removeAlert('imcMayor35');
                        }
                    }
                }
            });

            //calculo IMC2 Ventana modal editar
            $('#<%= txtDetallePeso2.ClientID %>').blur(function () {
                var peso = $('#<%= txtDetallePeso2.ClientID %>').val().replace(',', '.');
                if (!isNaN(peso) && peso > 0) {
                    var talla = $('#<%= txtTalla.ClientID %>').val().replace(',', '.');
                    if (!isNaN(talla) && talla > 0) {
                        var tempimc = calculo_imc(peso, talla);
                        $('#<%= txtDetalleIMC2.ClientID %>').val((+tempimc).toLocaleString());
                        if (tempimc > 35) {
                            addAlert('Controlar Peso.', 'imcMayor35');
                        } else {
                            removeAlert('imcMayor35');
                        }
                    }
                }
            });

            //Floating windows
            //scroll the message box to the top offset of browser's scrool bar
            //Mantiene la ventana flotando en a parte superior de la ventana
            $(window).scroll(function () {
                toppx = $(window).scrollTop() + 54;
                $('.alertBox').animate({ top: toppx + "px" }, { queue: false, duration: 350 });
                $('.alertBox').animate({ opacity: 0.9 }, { queue: false, duration: 350 });
            });
            ////Efecto de transparencia cuando no se esta usando la ventana
            //$('.alertBox').hover(function () {
            //    $('.alertBox').animate({ opacity: 1 }, { queue: false, duration: 350 });
            //}, function () {
            //    $('.alertBox').animate({ opacity: 0.5 }, { queue: false, duration: 350 });
            //});

            //ALERTAS/////////////////////////////////////////////////////////////
            //Edad (si se chequea < 15 y >35)
            $('#<%= rbEdad.ClientID %>').click(function () {
                radioChecked = $('#<%= rbEdad.ClientID %>').attr('checked');
                if (radioChecked) {
                    addAlert('Contemplar la Edad.', 'rbEdad');
                } else {
                    removeAlert('rbEdad');
                }
            });

            //Fin Embarazo anterior
            $('#<%= rbFinEmbAnteriorMenor1Año.ClientID %>').click(function () {
                radioChecked = $('#<%= rbFinEmbAnteriorMenor1Año.ClientID %>').attr('checked');
                if (radioChecked) {
                    addAlert('Fecha Embarazo Anterior < 1 año', 'rbFinEmbAnteriorMenor1Año');
                } else {
                    removeAlert('rbFinEmbAnteriorMenor1Año');
                }
            });

            //Alfabeta
            //            $('#<%= rbAlfabetaNo.ClientID %>').click(function() {
            //            radioChecked = $('#<%= rbAlfabetaNo.ClientID %>').attr('checked');
            //                if (radioChecked) {
            //                    addAlert('No Alfabeta.', 'rbAlfabetaNo');
            //                } else {
            //                removeAlert('rbAlfabetaNo');
            //                }
            //            });
            var alf = [{ control: '#<%= rbAlfabetaNo.ClientID %>', negativecontrol: '#<%= rbAlfabetaSi.ClientID %>' }];
            for (i = 0; i < alf.length; i++) {
                $(alf[i].control).click(function () {
                    radioChecked = jQuery(this).attr('checked');
                    if (radioChecked) {
                        addAlert(jQuery(this).parent().attr('alert-message'), jQuery(this).parent().attr('alert-group'));
                    } else {
                        removeAlert(jQuery(this).parent().attr('alert-group'));
                    }
                });
                $(alf[i].negativecontrol).click(function () {
                    radioChecked = jQuery(this).attr('checked');
                    if (radioChecked) {
                        removeAlert(jQuery(this).parent().attr('alert-group'));
                    }
                });
            }

            //Estudios
            $('#<%= rbEstudiosNinguno.ClientID %>').click(function () {
                radioChecked = $('#<%= rbEstudiosNinguno.ClientID %>').attr('checked');
                if (radioChecked) {
                    addAlert('No posee Estudios.', 'rbEstudiosNinguno');
                } else {
                    removeAlert('rbEstudiosNinguno');
                }
            });

            //Estado Civil soltera
            $('#<%= rbEstadoCivilSoltera.ClientID %>').click(function () {
                radioChecked = $('#<%= rbEstadoCivilSoltera.ClientID %>').attr('checked');
                if (radioChecked) {
                    addAlert('Estado civil Soltera.', 'rbEstadoCivilSoltera');
                } else {
                    removeAlert('rbEstadoCivilSoltera');
                }
            });

            //Estado Civil Otro
            $('#<%= rbEstadoCivilOtro.ClientID %>').click(function () {
                radioChecked = $('#<%= rbEstadoCivilOtro.ClientID %>').attr('checked');
                if (radioChecked) {
                    addAlert('Estado civil Otro.', 'rbEstadoCivilOtro');
                } else {
                    removeAlert('rbEstadoCivilOtro');
                }
            });

            //Vive Sola !ojo estan cambiados los valores del vive sola!!!!
            $('#<%= rbViveSolaNo.ClientID %>').click(function () {
                radioChecked = $('#<%= rbViveSolaNo.ClientID %>').attr('checked');
                if (radioChecked) {
                    addAlert('Vive Sola.', 'rbViveSolaNo');
                } else {
                    removeAlert('rbViveSolaNo');
                }
            });

            //Ultimo Previo 2500
            var ultimopr = [{ control: '#<%= rbUltimoPrevioMenor2500.ClientID %>', negativecontrol: '#<%= rbUltimoPrevioNoCorresponde.ClientID %>' },
            { control: '#<%= rbUltimoPrevioMayor4000.ClientID %>', negativecontrol: '#<%= rbUltimoPrevioNormal.ClientID %>' }];
            for (i = 0; i < ultimopr.length; i++) {
                $(ultimopr[i].control).click(function () {
                    radioChecked = jQuery(this).attr('checked');
                    if (radioChecked) {
                        addAlert(jQuery(this).parent().attr('alert-message'), jQuery(this).parent().attr('alert-group'));
                    } else {
                        removeAlert(jQuery(this).parent().attr('alert-group'));
                    }
                });
                $(ultimopr[i].negativecontrol).click(function () {
                    radioChecked = jQuery(this).attr('checked');
                    if (radioChecked) {
                        removeAlert(jQuery(this).parent().attr('alert-group'));
                    }
                });
            }

            //Antecedente de gemelares
            var gem = [{ control: '#<%= rbAntecedentesGemelaresSi.ClientID %>', negativecontrol: '#<%= rbAntecedentesGemelaresNo.ClientID %>' }];
            for (i = 0; i < gem.length; i++) {
                $(gem[i].control).click(function () {
                    radioChecked = jQuery(this).attr('checked');
                    if (radioChecked) {
                        addAlert(jQuery(this).parent().attr('alert-message'), jQuery(this).parent().attr('alert-group'));
                    } else {
                        removeAlert(jQuery(this).parent().attr('alert-group'));
                    }
                });
                $(gem[i].negativecontrol).click(function () {
                    radioChecked = jQuery(this).attr('checked');
                    if (radioChecked) {
                        removeAlert(jQuery(this).parent().attr('alert-group'));
                    }
                });
            }

            //Embarazo Planeado
            var emb = [{ control: '#<%= rbEmbarazoPlaneadoNo.ClientID %>', negativecontrol: '#<%= rbEmbarazoPlaneadoSi.ClientID %>' }];
            for (i = 0; i < emb.length; i++) {
                $(emb[i].control).click(function () {
                    radioChecked = jQuery(this).attr('checked');
                    if (radioChecked) {
                        addAlert(jQuery(this).parent().attr('alert-message'), jQuery(this).parent().attr('alert-group'));
                    } else {
                        removeAlert(jQuery(this).parent().attr('alert-group'));
                    }
                });
                $(emb[i].negativecontrol).click(function () {
                    radioChecked = jQuery(this).attr('checked');
                    if (radioChecked) {
                        removeAlert(jQuery(this).parent().attr('alert-group'));
                    }
                });
            }

            //            //Fracaso Metodo Anticonceptivo
            var fracaso = [{ control: '#<%= rbFracMetAnticonceptivoBarrera.ClientID %>', negativecontrol: '#<%= rbFracMetAnticonceptivoNoUsaba.ClientID %>' },
            { control: '#<%= rbFracMetAnticonceptivoDIU.ClientID %>', negativecontrol: '#<%= rbFracMetAnticonceptivoNoUsaba.ClientID %>' },
            { control: '#<%= rbFracMetAnticonceptivoHormonal.ClientID %>', negativecontrol: '#<%= rbFracMetAnticonceptivoNoUsaba.ClientID %>' },
            { control: '#<%= rbFracMetAnticonceptivoEmergencia.ClientID %>', negativecontrol: '#<%= rbFracMetAnticonceptivoNoUsaba.ClientID %>' },
            { control: '#<%= rbFracMetAnticonceptivoNatural.ClientID %>', negativecontrol: '#<%= rbFracMetAnticonceptivoNoUsaba.ClientID %>' }];
            for (i = 0; i < fracaso.length; i++) {
                $(fracaso[i].control).click(function () {
                    radioChecked = jQuery(this).attr('checked');
                    if (radioChecked) {
                        addAlert(jQuery(this).parent().attr('alert-message'), jQuery(this).parent().attr('alert-group'));
                    } else {
                        removeAlert(jQuery(this).parent().attr('alert-group'));
                    }
                });
                $(fracaso[i].negativecontrol).click(function () {
                    radioChecked = jQuery(this).attr('checked');
                    if (radioChecked) {
                        removeAlert(jQuery(this).parent().attr('alert-group'));
                    }
                });
            }

            //Ecog Confiable por FUM
            var ecof = [{ control: '#<%= rbEGConfiableFUMNo.ClientID %>', negativecontrol: '#<%= rbEGConfiableFUMSi.ClientID %>' }];
            for (i = 0; i < ecof.length; i++) {
                $(ecof[i].control).click(function () {
                    radioChecked = jQuery(this).attr('checked');
                    if (radioChecked) {
                        addAlert(jQuery(this).parent().attr('alert-message'), jQuery(this).parent().attr('alert-group'));
                    } else {
                        removeAlert(jQuery(this).parent().attr('alert-group'));
                    }
                });
                $(ecof[i].negativecontrol).click(function () {
                    radioChecked = jQuery(this).attr('checked');
                    if (radioChecked) {
                        removeAlert(jQuery(this).parent().attr('alert-group'));
                    }
                });
            }

            //Ecog Confiable por Eco
            var ecoe = [{ control: '#<%= rbEGConfiableEco20No.ClientID %>', negativecontrol: '#<%= rbEGConfiableEco20Si.ClientID %>' }];
            for (i = 0; i < ecoe.length; i++) {
                $(ecoe[i].control).click(function () {
                    radioChecked = jQuery(this).attr('checked');
                    if (radioChecked) {
                        addAlert(jQuery(this).parent().attr('alert-message'), jQuery(this).parent().attr('alert-group'));
                    } else {
                        removeAlert(jQuery(this).parent().attr('alert-group'));
                    }
                });
                $(ecoe[i].negativecontrol).click(function () {
                    radioChecked = jQuery(this).attr('checked');
                    if (radioChecked) {
                        removeAlert(jQuery(this).parent().attr('alert-group'));
                    }
                });
            }

            //Antirubeola
            var antirub = [{ control: '#<%= rbAntirubeolaNoSabe.ClientID %>', negativecontrol: '#<%= rbAntirubeolaPrevia.ClientID %>' },
            { control: '#<%= rbAntirubeolaEmbarazo.ClientID %>', negativecontrol: '#<%= rbAntirubeolaPrevia.ClientID %>' },
            { control: '#<%= rbAntirubeolaNo.ClientID %>', negativecontrol: '#<%= rbAntirubeolaPrevia.ClientID %>' }];
            for (i = 0; i < antirub.length; i++) {
                $(antirub[i].control).click(function () {
                    radioChecked = jQuery(this).attr('checked');
                    if (radioChecked) {
                        addAlert(jQuery(this).parent().attr('alert-message'), jQuery(this).parent().attr('alert-group'));
                    } else {
                        removeAlert(jQuery(this).parent().attr('alert-group'));
                    }
                });
                $(antirub[i].negativecontrol).click(function () {
                    radioChecked = jQuery(this).attr('checked');
                    if (radioChecked) {
                        removeAlert(jQuery(this).parent().attr('alert-group'));
                    }
                });
            }

            //Antitetanica
            var antit = [{ control: '#<%= rbAntitetanicaVigenteNo.ClientID %>', negativecontrol: '#<%= rbAntitetanicaVigenteSi.ClientID %>' }];
            for (i = 0; i < antit.length; i++) {
                $(antit[i].control).click(function () {
                    radioChecked = jQuery(this).attr('checked');
                    if (radioChecked) {
                        addAlert(jQuery(this).parent().attr('alert-message'), jQuery(this).parent().attr('alert-group'));
                    } else {
                        removeAlert(jQuery(this).parent().attr('alert-group'));
                    }
                });
                $(antit[i].negativecontrol).click(function () {
                    radioChecked = jQuery(this).attr('checked');
                    if (radioChecked) {
                        removeAlert(jQuery(this).parent().attr('alert-group'));
                    }
                });
            }

            //Examen Normal Odonto
            var exam = [{ control: '#<%= rbExNormalOdontNo.ClientID %>', negativecontrol: '#<%= rbExNormalOdontSi.ClientID %>' }];
            for (i = 0; i < exam.length; i++) {
                $(exam[i].control).click(function () {
                    radioChecked = jQuery(this).attr('checked');
                    if (radioChecked) {
                        addAlert(jQuery(this).parent().attr('alert-message'), jQuery(this).parent().attr('alert-group'));
                    } else {
                        removeAlert(jQuery(this).parent().attr('alert-group'));
                    }
                });
                $(exam[i].negativecontrol).click(function () {
                    radioChecked = jQuery(this).attr('checked');
                    if (radioChecked) {
                        removeAlert(jQuery(this).parent().attr('alert-group'));
                    }
                });
            }

            //Examen Normal Mamas
            var examM = [{ control: '#<%= rbExNormalMamasNo.ClientID %>', negativecontrol: '#<%= rbExNormalMamasSi.ClientID %>' }];
            for (i = 0; i < examM.length; i++) {
                $(examM[i].control).click(function () {
                    radioChecked = jQuery(this).attr('checked');
                    if (radioChecked) {
                        addAlert(jQuery(this).parent().attr('alert-message'), jQuery(this).parent().attr('alert-group'));
                    } else {
                        removeAlert(jQuery(this).parent().attr('alert-group'));
                    }
                });
                $(examM[i].negativecontrol).click(function () {
                    radioChecked = jQuery(this).attr('checked');
                    if (radioChecked) {
                        removeAlert(jQuery(this).parent().attr('alert-group'));
                    }
                });
            }
            //Fum Activa
            var fumact = [{ control: '#<%= rbFumaActiva1TrimSi.ClientID %>', negativecontrol: '#<%= rbFumaActiva1TrimNo.ClientID %>' },
            { control: '#<%= rbFumaActiva2TrimSi.ClientID %>', negativecontrol: '#<%= rbFumaActiva2TrimNo.ClientID %>' },
            { control: '#<%= rbFumaActiva3TrimSi.ClientID %>', negativecontrol: '#<%= rbFumaActiva3TrimNo.ClientID %>' }];
            for (i = 0; i < fumact.length; i++) {
                $(fumact[i].control).click(function () {
                    radioChecked = jQuery(this).attr('checked');
                    if (radioChecked) {
                        addAlert(jQuery(this).parent().attr('alert-message'), jQuery(this).parent().attr('alert-group'));
                    } else {
                        removeAlert(jQuery(this).parent().attr('alert-group'));
                    }
                });
                $(fumact[i].negativecontrol).click(function () {
                    radioChecked = jQuery(this).attr('checked');
                    if (radioChecked) {
                        removeAlert(jQuery(this).parent().attr('alert-group'));
                    }
                });
            }

            //Fum Pasiva
            var fumpas = [{ control: '#<%= rbFumaPasiva1TrimSi.ClientID %>', negativecontrol: '#<%= rbFumaPasiva1TrimNo.ClientID %>' },
            { control: '#<%= rbFumaPasiva2TrimSi.ClientID %>', negativecontrol: '#<%= rbFumaPasiva2TrimNo.ClientID %>' },
            { control: '#<%= rbFumaPasiva3TrimSi.ClientID %>', negativecontrol: '#<%= rbFumaPasiva3TrimNo.ClientID %>' }];
            for (i = 0; i < fumpas.length; i++) {
                $(fumpas[i].control).click(function () {
                    radioChecked = jQuery(this).attr('checked');
                    if (radioChecked) {
                        addAlert(jQuery(this).parent().attr('alert-message'), jQuery(this).parent().attr('alert-group'));
                    } else {
                        removeAlert(jQuery(this).parent().attr('alert-group'));
                    }
                });
                $(fumpas[i].negativecontrol).click(function () {
                    radioChecked = jQuery(this).attr('checked');
                    if (radioChecked) {
                        removeAlert(jQuery(this).parent().attr('alert-group'));
                    }
                });
            }

            //Drogas
            var drogas = [{ control: '#<%= rbDrogas1TrimSi.ClientID %>', negativecontrol: '#<%= rbDrogas1TrimNo.ClientID %>' },
            { control: '#<%= rbDrogas2TrimSi.ClientID %>', negativecontrol: '#<%= rbDrogas2TrimNo.ClientID %>' },
            { control: '#<%= rbDrogas3TrimSi.ClientID %>', negativecontrol: '#<%= rbDrogas3TrimNo.ClientID %>' }];
            for (i = 0; i < drogas.length; i++) {
                $(drogas[i].control).click(function () {
                    radioChecked = jQuery(this).attr('checked');
                    if (radioChecked) {
                        addAlert(jQuery(this).parent().attr('alert-message'), jQuery(this).parent().attr('alert-group'));
                    } else {
                        removeAlert(jQuery(this).parent().attr('alert-group'));
                    }
                });
                $(drogas[i].negativecontrol).click(function () {
                    radioChecked = jQuery(this).attr('checked');
                    if (radioChecked) {
                        removeAlert(jQuery(this).parent().attr('alert-group'));
                    }
                });
            }

            //Alcohol
            var alco = [{ control: '#<%= rbAlcohol1TrimSi.ClientID %>', negativecontrol: '#<%= rbAlcohol1TrimNo.ClientID %>' },
            { control: '#<%= rbAlcohol2TrimSi.ClientID %>', negativecontrol: '#<%= rbAlcohol2TrimNo.ClientID %>' },
            { control: '#<%= rbAlcohol3TrimSi.ClientID %>', negativecontrol: '#<%= rbAlcohol3TrimNo.ClientID %>' }];
            for (i = 0; i < alco.length; i++) {
                $(alco[i].control).click(function () {
                    radioChecked = jQuery(this).attr('checked');
                    if (radioChecked) {
                        addAlert(jQuery(this).parent().attr('alert-message'), jQuery(this).parent().attr('alert-group'));
                    } else {
                        removeAlert(jQuery(this).parent().attr('alert-group'));
                    }
                });
                $(alco[i].negativecontrol).click(function () {
                    radioChecked = jQuery(this).attr('checked');
                    if (radioChecked) {
                        removeAlert(jQuery(this).parent().attr('alert-group'));
                    }
                });
            }

            //Violencia
            var violen = [{ control: '#<%= rbViolencia1TrimSi.ClientID %>', negativecontrol: '#<%= rbViolencia1TrimNo.ClientID %>' },
            { control: '#<%= rbViolencia2TrimSi.ClientID %>', negativecontrol: '#<%= rbViolencia2TrimNo.ClientID %>' },
            { control: '#<%= rbViolencia3TrimSi.ClientID %>', negativecontrol: '#<%= rbViolencia3TrimNo.ClientID %>' }];
            for (i = 0; i < violen.length; i++) {
                $(violen[i].control).click(function () {
                    radioChecked = jQuery(this).attr('checked');
                    if (radioChecked) {
                        addAlert(jQuery(this).parent().attr('alert-message'), jQuery(this).parent().attr('alert-group'));
                    } else {
                        removeAlert(jQuery(this).parent().attr('alert-group'));
                    }
                });
                $(violen[i].negativecontrol).click(function () {
                    radioChecked = jQuery(this).attr('checked');
                    if (radioChecked) {
                        removeAlert(jQuery(this).parent().attr('alert-group'));
                    }
                });
            }

            //Glucemia mayor a 100 (Muestra antes de las 20 semanas)
            $('#<%= rbGlucemiaMenos20Mayor105.ClientID %>').click(function () {
                radioChecked = $('#<%= rbGlucemiaMenos20Mayor105.ClientID %>').attr('checked');
                if (radioChecked) {
                    addAlert('Controlar Glucemia.', 'rbGlucemiaMenos20Mayor105');
                } else {
                    removeAlert('rbGlucemiaMenos20Mayor105');
                }
            });

            //Glucemia mayor a 100 (Muestra despues de las 30 semanas)
            $('#<%= rbGlucemiaMas30Mayor105.ClientID %>').click(function () {
                radioChecked = $('#<%= rbGlucemiaMas30Mayor105.ClientID %>').attr('checked');
                if (radioChecked) {
                    addAlert('Controlar Glucemia.', 'rbGlucemiaMas30Mayor105');
                } else {
                    removeAlert('rbGlucemiaMas30Mayor105');
                }
            });

            //Hemoglobina Menor a 11 (Mustra antes de las 20 semanas)
            $('#<%= rbHemoglobinaMenos20Menor11.ClientID %>').click(function () {
                radioChecked = $('#<%= rbHemoglobinaMenos20Menor11.ClientID %>').attr('checked');
                if (radioChecked) {
                    addAlert('Indicar Fe/FOLATOS.', 'rbHemoglobinaMenos20Menor11');
                } else {
                    removeAlert('rbHemoglobinaMenos20Menor11');
                }
            });

            //Hemoglobina Menor a 11 (Mustra despues de las 20 semanas)
            $('#<%= rbHemoglobinaMas20Menor11.ClientID %>').click(function () {
                radioChecked = $('#<%= rbHemoglobinaMas20Menor11.ClientID %>').attr('checked');
                if (radioChecked) {
                    addAlert('Indicar Fe/FOLATOS.', 'rbHemoglobinaMas20Menor11');
                } else {
                    removeAlert('rbHemoglobinaMas20Menor11');
                }
            });

            //Prueba no trepodermica de sifilis positiva
            $('#<%= rbSifilisPruebaNTPrimerMuestraPositivo.ClientID %>').click(function () {
                radioChecked = $('#<%= rbSifilisPruebaNTPrimerMuestraPositivo.ClientID %>').attr('checked');
                if (radioChecked) {
                    addAlert('Indicar Prueba Trepodermica y Tratamiento para SIFILIS.', 'rbSifilisPruebaNT');
                } else {
                    removeAlert('rbSifilisPruebaNT');
                }
            });
            $('#<%= rbSifilisPruebaNTSegundaMuestraPositivo.ClientID %>').click(function () {
                radioChecked = $('#<%= rbSifilisPruebaNTSegundaMuestraPositivo.ClientID %>').attr('checked');
                if (radioChecked) {
                    addAlert('Indicar Prueba Trepodermica y Tratamiento para SIFILIS.', 'rbSifilisPruebaNT');
                } else {
                    removeAlert('rbSifilisPruebaNT');
                }
            });
            $('#<%= rbSifilisPruebaNTTercerMuestraPositivo.ClientID %>').click(function () {
                radioChecked = $('#<%= rbSifilisPruebaNTTercerMuestraPositivo.ClientID %>').attr('checked');
                if (radioChecked) {
                    addAlert('Indicar Prueba Trepodermica y Tratamiento para SIFILIS.', 'rbSifilisPruebaNT');
                } else {
                    removeAlert('rbSifilisPruebaNT');
                }
            });
            //Prueba no trepodermica de sifilis sin datos
            $('#<%= rbSifilisPruebaNTPrimerMuestraSD.ClientID %>').click(function () {
                radioChecked = $('#<%= rbSifilisPruebaNTPrimerMuestraSD.ClientID %>').attr('checked');
                if (radioChecked) {
                    addAlert('Indicar Prueba Trepodermica y Tratamiento para SIFILIS.', 'rbSifilisPruebaNT');
                } else {
                    removeAlert('rbSifilisPruebaNT');
                }
            });
            $('#<%= rbSifilisPruebaNTSegundaMuestraSD.ClientID %>').click(function () {
                radioChecked = $('#<%= rbSifilisPruebaNTSegundaMuestraSD.ClientID %>').attr('checked');
                if (radioChecked) {
                    addAlert('Indicar Prueba Trepodermica y Tratamiento para SIFILIS.', 'rbSifilisPruebaNT');
                } else {
                    removeAlert('rbSifilisPruebaNT');
                }
            });
            $('#<%= rbSifilisPruebaNTTercerMuestraSD.ClientID %>').click(function () {
                radioChecked = $('#<%= rbSifilisPruebaNTTercerMuestraSD.ClientID %>').attr('checked');
                if (radioChecked) {
                    addAlert('Indicar Prueba Trepodermica y Tratamiento para SIFILIS.', 'rbSifilisPruebaNT');
                } else {
                    removeAlert('rbSifilisPruebaNT');
                }
            });
            //EG x FUM Confiable=No
            $('#<%= rbEGConfiableFUMNo.ClientID %>').click(function () {
                radioChecked = $('#<%= rbEGConfiableFUMNo.ClientID %>').attr('checked');
                if (radioChecked) {
                    addAlert('Indicar ecografia para determinar la Edad Gestacional.', 'rbEGConfiableFUMNo');
                } else {
                    removeAlert('rbEGConfiableFUMNo');
                }
            });
            //Fum confiable=Si
            $('#<%= rbEGConfiableFUMSi.ClientID %>').click(function () {
                radioChecked = $('#<%= rbEGConfiableFUMSi.ClientID %>').attr('checked');
                if (radioChecked) {
                    $('#<%= txtFUM.ClientID %>').addClass('validate[required]');
                } else {
                    $('#<%= txtFUM.ClientID %>').removeClass('validate[required]');
                    $(".formError").remove();
                }
            });

            //EG x ECO Confiable=Si
            $('#<%= rbEGConfiableEco20Si.ClientID %>').click(function () {
                radioChecked = $('#<%= rbEGConfiableEco20Si.ClientID %>').attr('checked');
                if (radioChecked) {
                    $('#<%= txtFPP.ClientID %>').addClass('validate[required]');
                    addAlert('Se debe cargar la FPP y la Edad gestacional', 'rbEGConfiableEco20si');
                } else {
                    $('#<%= txtFPP.ClientID %>').removeClass('validate[required]');
                    $(".formError").remove();
                    removeAlert('rbEGConfiableEco20si');
                }
            });


            //Antecedentes Personales
            var antecedentes = [{ control: '#<%= rbAntecedentePersonalTBCSi.ClientID %>', negativecontrol: '#<%= rbAntecedentePersonalTBCNo.ClientID %>' },
            { control: '#<%=rbAntecedentePersonalAlergiaMedicamentoSi.ClientID %>', negativecontrol: '#<%=rbAntecedentePersonalAlergiaMedicamentoNo.ClientID %>' },
            { control: '#<%=rbAntecedentePersonalViolenciaSi.ClientID %>', negativecontrol: '#<%=rbAntecedentePersonalViolenciaNo.ClientID %>' },
            { control: '#<%=rbAntecedentePersonalNefropatiaSi.ClientID %>', negativecontrol: '#<%=rbAntecedentePersonalNefropatiaNo.ClientID %>' },
            { control: '#<%=rbAntecedentePersonalCardiopatiaSi.ClientID %>', negativecontrol: '#<%=rbAntecedentePersonalCardiopatiaNo.ClientID %>' },
            { control: '#<%=rbAntecedentePersonalInfertilidadSi.ClientID %>', negativecontrol: '#<%=rbAntecedentePersonalInfertilidadNo.ClientID %>' },
            { control: '#<%=rbAntecedentePersonalOtraCondSi.ClientID %>', negativecontrol: '#<%=rbAntecedentePersonalOtraCondNo.ClientID %>' },
            { control: '#<%=rbAntecedentePersonalOtrasInfeccionesSi.ClientID %>', negativecontrol: '#<%=rbAntecedentePersonalOtrasInfeccionesNo.ClientID %>' },
            { control: '#<%=rbAntecedentePersonalInfUrinariaSi.ClientID %>', negativecontrol: '#<%=rbAntecedentePersonalInfUrinariaNo.ClientID %>' },
            { control: '#<%=rbAntecedentePersonalHipertensionSi.ClientID %>', negativecontrol: '#<%=rbAntecedentePersonalHipertensionNo.ClientID %>' },
            { control: '#<%=rbAntecedentePersonalDiabetesG.ClientID %>', negativecontrol: '#<%=rbAntecedentePersonalDiabetesNo.ClientID %>' },
            { control: '#<%=rbAntecedentePersonalDiabetesII.ClientID %>', negativecontrol: '#<%=rbAntecedentePersonalDiabetesNo.ClientID %>' },
            { control: '#<%=rbAntecedentePersonalDiabetesI.ClientID %>', negativecontrol: '#<%=rbAntecedentePersonalDiabetesNo.ClientID %>' }];
            for (i = 0; i < antecedentes.length; i++) {
                //$(antecedentes[i].control).change(alertManager);
                $(antecedentes[i].control).click(function () {
                    radioChecked = jQuery(this).attr('checked');
                    if (radioChecked) {
                        addAlert(jQuery(this).parent().attr('alert-message'), jQuery(this).parent().attr('alert-group'));
                    } else {
                        removeAlert(jQuery(this).parent().attr('alert-group'));
                    }
                });
                $(antecedentes[i].negativecontrol).click(function () {
                    radioChecked = jQuery(this).attr('checked');
                    if (radioChecked) {
                        removeAlert(jQuery(this).parent().attr('alert-group'));
                    }
                });
            }

            //Patologias Actuales Gineco Obstetricas
            var patgo = [{ control: '#<%= rbAgoActualColestasisSi.ClientID %>', negativecontrol: '#<%= rbAgoActualColestasisNo.ClientID %>' },
            { control: '#<%= rbAgoActualColestasisSi.ClientID %>', negativecontrol: '#<%= rbAgoActualColestasisNo.ClientID %>' },
            { control: '#<%= rbAgoActualIsoInmunizacionesSi.ClientID %>', negativecontrol: '#<%= rbAgoActualIsoInmunizacionesNo.ClientID %>' },
            { control: '#<%= rbAgoActualRPMembranasSi.ClientID %>', negativecontrol: '#<%= rbAgoActualRPMembranasNo.ClientID %>' },
            { control: '#<%= rbAgoActualOligoanmiosSi.ClientID %>', negativecontrol: '#<%= rbAgoActualOligoanmiosNo.ClientID %>' },
            { control: '#<%= rbAgoActualPolihidramniosSi.ClientID %>', negativecontrol: '#<%= rbAgoActualPolihidramniosNo.ClientID %>' },
            { control: '#<%= rbAgoActualMacrosomoiaFetalSi.ClientID %>', negativecontrol: '#<%= rbAgoActualMacrosomoiaFetalNo.ClientID %>' },
            { control: '#<%= rbAgoActualHemorragiaObstetricaSi.ClientID %>', negativecontrol: '#<%= rbAgoActualHemorragiaObstetricaNo.ClientID %>' },
            { control: '#<%= rbAgoActualRCIUSi.ClientID %>', negativecontrol: '#<%= rbAgoActualRCIUNo.ClientID %>' },
            { control: '#<%= rbAgoActualAPPrematuraSi.ClientID %>', negativecontrol: '#<%= rbAgoActualAPPrematuraNo.ClientID %>' },
            { control: '#<%= rbAgoActualCirugiaGUSi.ClientID %>', negativecontrol: '#<%= rbAgoActualCirugiaGUNo.ClientID %>' },
            { control: '#<%= rbAgoActualPreeclampsiaSi.ClientID %>', negativecontrol: '#<%= rbAgoActualPreeclampsiaNo.ClientID %>' },
            { control: '#<%= rbAgoActualEclampsiaSi.ClientID %>', negativecontrol: '#<%= rbAgoActualEclampsiaNo.ClientID %>' }];
            for (i = 0; i < patgo.length; i++) {
                //$(antecedentes[i].control).change(alertManager);
                $(patgo[i].control).click(function () {
                    radioChecked = jQuery(this).attr('checked');
                    if (radioChecked) {
                        addAlert(jQuery(this).parent().attr('alert-message'), jQuery(this).parent().attr('alert-group'));
                    } else {
                        removeAlert(jQuery(this).parent().attr('alert-group'));
                    }
                });
                $(patgo[i].negativecontrol).click(function () {
                    radioChecked = jQuery(this).attr('checked');
                    if (radioChecked) {
                        removeAlert(jQuery(this).parent().attr('alert-group'));
                    }
                });
            }

            //Factores de Riesgo
            var factriesgo = [{ control: '#<%= rbFactorRiesgoEmbarazoSinContSocialSi.ClientID %>', negativecontrol: '#<%= rbFactorRiesgoEmbarazoSinContSocialNo.ClientID %>' },
            { control: '#<%= rbFactorRiesgoFamiliaSinIngresosFijosSi.ClientID %>', negativecontrol: '#<%= rbFactorRiesgoFamiliaSinIngresosFijosNo.ClientID %>' },
            { control: '#<%= rbFactorRiesgoEmbarazoFuertRechazadoSi.ClientID %>', negativecontrol: '#<%= rbFactorRiesgoEmbarazoFuertRechazadoNo.ClientID %>' },
            { control: '#<%= rbFactorRiesgoHijosDadosAdopcionSi.ClientID %>', negativecontrol: '#<%= rbFactorRiesgoHijosDadosAdopcionNo.ClientID %>' },
            { control: '#<%= rbFactorRiesgoViviendaSinServiciosBasicosSi.ClientID %>', negativecontrol: '#<%= rbFactorRiesgoViviendaSinServiciosBasicosNo.ClientID %>' }];
            for (i = 0; i < factriesgo.length; i++) {
                //$(antecedentes[i].control).change(alertManager);
                $(factriesgo[i].control).click(function () {
                    radioChecked = jQuery(this).attr('checked');
                    if (radioChecked) {
                        addAlert(jQuery(this).parent().attr('alert-message'), jQuery(this).parent().attr('alert-group'));
                    } else {
                        removeAlert(jQuery(this).parent().attr('alert-group'));
                    }
                });
                $(factriesgo[i].negativecontrol).click(function () {
                    radioChecked = jQuery(this).attr('checked');
                    if (radioChecked) {
                        removeAlert(jQuery(this).parent().attr('alert-group'));
                    }
                });
            }
        });

        //Muestra el alert por los segundos seteados..
        var idAuto = 0;
        function addAlert(message, id) {
            removeAlert(id);
            $("#ulAlert").append('<div class="alert alert-danger alert-dismissible fade in" id="'+idAuto+'" role="alert"><button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>' + message + '</div>');
            var idConc='#' + idAuto;
            $(idConc).fadeIn(1500);
            setTimeout(function () {
                $(idConc).fadeOut(1500);
            }, 3000);
            idAuto = idAuto + 1;
        }
        function addAlertOK(message, id) {
            removeAlert(id);
            $("#ulAlert").append('<div class="alert alert-success alert-dismissible fade in" id="' + idAuto + '" role="alert"><button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>' + message + '</div>');
            var idConc = '#' + idAuto;
            $(idConc).fadeIn(1500);
            setTimeout(function () {
                $(idConc).fadeOut(1500);
            }, 6000);
            idAuto = idAuto + 1;
        }

        function addAlertOFF(message, id) {
            removeAlert(id);
            $("#ulAlert").append('<div class="alert alert-danger alert-dismissible fade in" id="' + idAuto + '" role="alert"><button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>' + message + '</div>');
            var idConc = '#' + idAuto;
            $(idConc).fadeIn(1500);
            setTimeout(function () {
                $(idConc).fadeOut(1500);
            }, 6000);
            idAuto = idAuto + 1;
        }

        function removeAlert(id) {
            $("#ulAlert #" + id).remove();
        }
        //end floating window interaction
        function calculo_imc(peso, talla) {
            var tallatemp = talla / 100;
            return (peso / (tallatemp * tallatemp)).toFixed(2);
        }
        //function weeks_between(date1, date2) {
        //    var days = days_between(date1, date2);
        //    var tempw = Math.floor(days / 7);
        //    var tempd = days % 7;
        //    return tempw + ',' + tempd;
        //}
        //function days_between(date1, date2) {
        //    //debugger;
        //    // The number of milliseconds in one day
        //    var ONE_DAY = 1000 * 60 * 60 * 24
        //    // Convert both dates to milliseconds
        //    var date1_ms = date1.getTime()
        //    var date2_ms = date2.getTime()
        //    // Calculate the difference in milliseconds
        //    var difference_ms = Math.abs(date1_ms - date2_ms)
        //    // Convert back to days and return
        //    return Math.round(difference_ms / ONE_DAY)
        //}
        //function addAlert(message, id) {
        //    removeAlert(id);
        //    $("#ulAlert").append('<li id=' + id + '><a href=javascript:removeAlert("' + id + '");>' + message + '</a></li>');
        //}

        

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="server">

    

    <div class="alertBox">


       <div id="ulAlert"> </div>

       <%-- <div class="ui-state-highlight ui-corner-all" style="padding: 5px; min-width: 180px;">
            <div class="ui-state-error ui-corner-all alertBoxTitle" style="padding: 5px; width: 95%;">
                Alertas
            </div>
            <ul id="ulAlert">
            </ul>
        </div>--%>
    </div>
    <asp:HiddenField runat="server" ID="hfPrimerControl" />

    <div id="print">
    <asp:Panel id="printPanel" runat="server" Enabled="true">
        <script>

            function imprimir() {
                //debugger;
                // e.preventDefault();
                html2canvas($("#print"), {
                    onrendered: function (canvas) {
                        var myImage = canvas.toDataURL("image/png");
                        window.open(myImage, '_blank');
                        //window.document.close(); // necessary for IE >= 10
                        //window.focus(); // necessary for IE >= 10
                        //window.print();
                        //window.close();
                    }
                });

            }



        </script>
        <div id="divControl">
            <div id="sipContainer">
                <!-- Datos Basicos -->
                <asp:Label runat="server" ID="lblNombre" CssClass="lblNombre smallCaps" Text="Nombre"></asp:Label>
                <asp:Label runat="server" ID="lblApellido" CssClass="lblApellido smallCaps" Text="Apellido"></asp:Label>
                <asp:Label runat="server" ID="lblDomicilio" CssClass="lblDomicilio smallCaps" Text="Domicilio 123"></asp:Label>
                <asp:Label runat="server" ID="lblDocumento" CssClass="lblDocumento smallCaps" Text="00000000"></asp:Label>
                <asp:Label runat="server" ID="lblTelefono" CssClass="lblTelefono smallCaps" Text="123-456-789"></asp:Label>
                <asp:Label runat="server" ID="lblLocalidad" CssClass="lblLocalidad smallCaps" Text="Neuquen"></asp:Label>
                <!-- Link a Datos de contacto -->
                <div>
                    <asp:TextBox runat="server" ID="txtDatosContacto" CssClass="txtDatosContacto textBoxchars"
                        ToolTip="Ingresar Datos de Contacto"></asp:TextBox>
                </div>
                <!-- Fecha Nacimiento -->
                <asp:Label runat="server" ID="lblDiaNacimeinto" CssClass="lblDiaNacimiento normalNumbers"
                    Text="29"></asp:Label>
                <asp:Label runat="server" ID="lblMesNacimiento" CssClass="lblMesNacimiento normalNumbers"
                    Text="08"></asp:Label>
                <asp:Label runat="server" ID="lblAñoNacimiento" CssClass="lblAñoNacimiento normalNumbers"
                    Text="06"></asp:Label>
                <asp:HiddenField runat="server" ID="hfFechaNacimiento" />
                <!-- Edad -->
                <asp:Label runat="server" ID="lblEdad" CssClass="lblEdad normalNumbers"></asp:Label>
                <asp:RadioButton runat="server" ID="rbEdad" CssClass="rbEdad" alert-message="Contemmplar Edad" />
                <!-- Etnia -->
                <asp:RadioButton runat="server" ID="rbEtniaBlanca" GroupName="Etnia" CssClass="rbEtniaBlanca" />
                <asp:RadioButton runat="server" ID="rbEtniaIndigena" GroupName="Etnia" CssClass="rbEtniaIndigena" />
                <asp:RadioButton runat="server" ID="rbEtniaMestiza" GroupName="Etnia" CssClass="rbEtniaMestiza" />
                <asp:RadioButton runat="server" ID="rbEtniaNegra" GroupName="Etnia" CssClass="rbEtniaNegra" />
                <asp:RadioButton runat="server" ID="rbEtniaOtra" GroupName="Etnia" CssClass="rbEtniaOtra" />
                <!-- Alfabeta -->
                <asp:RadioButton runat="server" ID="rbAlfabetaNo" GroupName="Alfabeta" CssClass="rbAlfabetaNo"
                    alert-message="Paciente No Alfabeta" alert-group="Alfabeta" />
                <asp:RadioButton runat="server" ID="rbAlfabetaSi" GroupName="Alfabeta" CssClass="rbAlfabetaSi"
                    alert-group="Alfabeta" />
                <!-- Estudios -->
                <asp:RadioButton runat="server" ID="rbEstudiosNinguno" GroupName="Estudios" CssClass="rbEstudiosNinguno"
                    alert-message="No posee Estudios" />
                <asp:RadioButton runat="server" ID="rbEstudiosPrimaria" GroupName="Estudios" CssClass="rbEstudiosPrimaria" />
                <asp:RadioButton runat="server" ID="rbEstudiosSecundario" GroupName="Estudios" CssClass="rbEstudiosSecundario" />
                <asp:RadioButton runat="server" ID="rbEstudiosUniversitarios" GroupName="Estudios"
                    CssClass="rbEstudiosUniversitarios" />
                <asp:TextBox runat="server" ID="txtEstudiosAniosMayorNivel" Columns="1" CssClass="txtEstudiosAniosMayorNivel textBox1chars"></asp:TextBox>
                <!-- Estadoo Civil -->
                <asp:RadioButton runat="server" ID="rbEstadoCivilCasada" GroupName="EstadoCivil"
                    CssClass="rbEstadoCivilCasada" />
                <asp:RadioButton runat="server" ID="rbEstadoCivilUnionEstable" GroupName="EstadoCivil"
                    CssClass="rbEstadoCivilUnionEstable" />
                <asp:RadioButton runat="server" ID="rbEstadoCivilSoltera" GroupName="EstadoCivil"
                    CssClass="rbEstadoCivilSoltera" />
                <asp:RadioButton runat="server" ID="rbEstadoCivilOtro" GroupName="EstadoCivil" CssClass="rbEstadoCivilOtro" />
                <!-- Vive Sola -->
                <asp:RadioButton runat="server" ID="rbViveSolaSi" GroupName="ViveSola" CssClass="rbViveSolaSi" />
                <asp:RadioButton runat="server" ID="rbViveSolaNo" GroupName="ViveSola" CssClass="rbViveSolaNo"
                    alert-message="Vive Sola" />
                <!-- Lugares - Indentidad -->
                <asp:Label runat="server" ID="lblLugarControlPerinatal" CssClass="lblLugarControlPerinatal normalNumbers"></asp:Label>
                <asp:Label runat="server" ID="lblLugarPartoAborto" CssClass="lblLugarPartoAborto normalNumbers"></asp:Label>
                <!-- Lugares - Traslado Intrauterino  -->
                <asp:Label runat="server" ID="lblLugarTraslado" CssClass="lblNumeroIdentidad normalNumbers" ToolTip="Efector donde se realiza el traslado Intrauterino"></asp:Label>
                <!-- Antecedentes Familiares -->
                <!-- TBC -->
                <asp:RadioButton runat="server" ID="rbAntecedenteFamiliarTBCNo" GroupName="AntecedenteFamiliarTBC"
                    CssClass="rbAntecedenteFamiliarTBCNo" />
                <asp:RadioButton runat="server" ID="rbAntecedenteFamiliarTBCSi" GroupName="AntecedenteFamiliarTBC"
                    CssClass="rbAntecedenteFamiliarTBCSi" />
                <!-- diabetes -->
                <asp:RadioButton runat="server" ID="rbAntecedenteFamiliarDiabetesNo" GroupName="AntecedenteFamiliarDiabetes"
                    CssClass="rbAntecedenteFamiliarDiabetesNo" />
                <asp:RadioButton runat="server" ID="rbAntecedenteFamiliarDiabetesSi" GroupName="AntecedenteFamiliarDiabetes"
                    CssClass="rbAntecedenteFamiliarDiabetesSi" />
                <!-- hipertension -->
                <asp:RadioButton runat="server" ID="rbAntecedenteFamiliarHipertensionNo" GroupName="AntecedenteFamiliarHipertension"
                    CssClass="rbAntecedenteFamiliarHipertensionNo" />
                <asp:RadioButton runat="server" ID="rbAntecedenteFamiliarHipertensionSi" GroupName="AntecedenteFamiliarHipertension"
                    CssClass="rbAntecedenteFamiliarHipertensionSi" />
                <!-- preeclampsia -->
                <asp:RadioButton runat="server" ID="rbAntecedenteFamiliarInfUrinariaNo" GroupName="AntecedenteFamiliarInfUrinaria"
                    CssClass="rbAntecedenteFamiliarInfUrinariaNo" />
                <asp:RadioButton runat="server" ID="rbAntecedenteFamiliarInfUrinariaSi" GroupName="AntecedenteFamiliarInfUrinaria"
                    CssClass="rbAntecedenteFamiliarInfUrinariaSi" />
                <!-- eclampsia -->
                <asp:RadioButton runat="server" ID="rbAntecedenteFamiliarOtrasInfeccionesNo" GroupName="AntecedenteFamiliarOtrasInfecciones"
                    CssClass="rbAntecedenteFamiliarOtrasInfeccionesNo" />
                <asp:RadioButton runat="server" ID="rbAntecedenteFamiliarOtrasInfeccionesSi" GroupName="AntecedenteFamiliarOtrasInfecciones"
                    CssClass="rbAntecedenteFamiliarOtrasInfeccionesSi" />
                <!-- otracond -->
                <asp:RadioButton runat="server" ID="rbAntecedenteFamiliarOtraCondNo" GroupName="AntecedenteFamiliarOtraCond"
                    CssClass="rbAntecedenteFamiliarOtraCondNo" />
                <asp:RadioButton runat="server" ID="rbAntecedenteFamiliarOtraCondSi" GroupName="AntecedenteFamiliarOtraCond"
                    CssClass="rbAntecedenteFamiliarOtraCondSi" />
                <!-- Antecedentes Personales -->
                <!-- TBC -->
                <asp:RadioButton runat="server" ID="rbAntecedentePersonalTBCNo" GroupName="AntecedentePersonalTBC"
                    CssClass="rbAntecedentePersonalTBCNo" alert-group="TBC" />
                <asp:RadioButton runat="server" ID="rbAntecedentePersonalTBCSi" GroupName="AntecedentePersonalTBC"
                    CssClass="rbAntecedentePersonalTBCSi" alert-message="Ant. Personal: TBC" alert-group="TBC" />
                <!-- diabetes -->
                <asp:RadioButton runat="server" ID="rbAntecedentePersonalDiabetesNo" GroupName="AntecedentePersonalDiabetes"
                    CssClass="rbAntecedentePersonalDiabetesNo" alert-group="Diabetes" />
                <asp:RadioButton runat="server" ID="rbAntecedentePersonalDiabetesI" GroupName="AntecedentePersonalDiabetes"
                    CssClass="rbAntecedentePersonalDiabetesI" alert-message="Ant. Personal: Diabetes I"
                    alert-group="Diabetes" />
                <asp:RadioButton runat="server" ID="rbAntecedentePersonalDiabetesII" GroupName="AntecedentePersonalDiabetes"
                    CssClass="rbAntecedentePersonalDiabetesII" alert-message="Ant. Personal: Diabetes II"
                    alert-group="Diabetes" />
                <asp:RadioButton runat="server" ID="rbAntecedentePersonalDiabetesG" GroupName="AntecedentePersonalDiabetes"
                    CssClass="rbAntecedentePersonalDiabetesG" alert-message="Ant. Personal: Diabetes G"
                    alert-group="Diabetes" />
                <!-- hipertension -->
                <asp:RadioButton runat="server" ID="rbAntecedentePersonalHipertensionNo" GroupName="AntecedentePersonalHipertension"
                    CssClass="rbAntecedentePersonalHipertensionNo" alert-group="Hipertension" />
                <asp:RadioButton runat="server" ID="rbAntecedentePersonalHipertensionSi" GroupName="AntecedentePersonalHipertension"
                    CssClass="rbAntecedentePersonalHipertensionSi" alert-message="Ant. Personal: Hipertension"
                    alert-group="Hipertension" />
                <!-- Inf Urinaria -->
                <asp:RadioButton runat="server" ID="rbAntecedentePersonalInfUrinariaNo" GroupName="AntecedentePersonalInfUrinaria"
                    CssClass="rbAntecedentePersonalInfUrinariaNo" alert-group="InfUrinaria" />
                <asp:RadioButton runat="server" ID="rbAntecedentePersonalInfUrinariaSi" GroupName="AntecedentePersonalInfUrinaria"
                    CssClass="rbAntecedentePersonalInfUrinariaSi" alert-message="Ant. Personal: Infeccion Urinaria"
                    alert-group="InfUrinaria" />
                <!-- Otras Infecciones -->
                <asp:RadioButton runat="server" ID="rbAntecedentePersonalOtrasInfeccionesNo" GroupName="AntecedentePersonalOtrasInfecciones"
                    CssClass="rbAntecedentePersonalOtrasInfeccionesNo" alert-group="OtrasInfecciones" />
                <asp:RadioButton runat="server" ID="rbAntecedentePersonalOtrasInfeccionesSi" GroupName="AntecedentePersonalOtrasInfecciones"
                    CssClass="rbAntecedentePersonalOtrasInfeccionesSi" alert-message="Ant. Personal: Otras Infecciones"
                    alert-group="OtrasInfecciones" />
                <!-- otracond -->
                <asp:RadioButton runat="server" ID="rbAntecedentePersonalOtraCondNo" GroupName="AntecedentePersonalOtraCond"
                    CssClass="rbAntecedentePersonalOtraCondNo" alert-group="OtrasInfecciones" />
                <asp:RadioButton runat="server" ID="rbAntecedentePersonalOtraCondSi" GroupName="AntecedentePersonalOtraCond"
                    CssClass="rbAntecedentePersonalOtraCondSi" alert-message="Ant. Personal: Otra Condicion"
                    alert-group="OtrasInfecciones" />
                <!-- infertilidad -->
                <asp:RadioButton runat="server" ID="rbAntecedentePersonalInfertilidadNo" GroupName="AntecedentePersonalInfertilidad"
                    CssClass="rbAntecedentePersonalInfertilidadNo" alert-group="Infertilidad" />
                <asp:RadioButton runat="server" ID="rbAntecedentePersonalInfertilidadSi" GroupName="AntecedentePersonalInfertilidad"
                    CssClass="rbAntecedentePersonalInfertilidadSi" alert-message="Ant. Personal: Infertilidad"
                    alert-group="Infertilidad" />
                <!-- cardiopatia -->
                <asp:RadioButton runat="server" ID="rbAntecedentePersonalCardiopatiaNo" GroupName="AntecedentePersonalCardiopatia"
                    CssClass="rbAntecedentePersonalCardiopatiaNo" alert-group="Cardiopatia" />
                <asp:RadioButton runat="server" ID="rbAntecedentePersonalCardiopatiaSi" GroupName="AntecedentePersonalCardiopatia"
                    CssClass="rbAntecedentePersonalCardiopatiaSi" alert-message="Ant. Personal: Cardiopatia"
                    alert-group="Cardiopatia" />
                <!-- nefropatia -->
                <asp:RadioButton runat="server" ID="rbAntecedentePersonalNefropatiaNo" GroupName="AntecedentePersonalNefropatia"
                    CssClass="rbAntecedentePersonalNefropatiaNo" alert-group="Nefropatia" />
                <asp:RadioButton runat="server" ID="rbAntecedentePersonalNefropatiaSi" GroupName="AntecedentePersonalNefropatia"
                    CssClass="rbAntecedentePersonalNefropatiaSi" alert-message="Ant. Personal: Nefropatia"
                    alert-group="Nefropatia" />
                <!-- violencia -->
                <asp:RadioButton runat="server" ID="rbAntecedentePersonalViolenciaNo" GroupName="AntecedentePersonalViolencia"
                    CssClass="rbAntecedentePersonalViolenciaNo" alert-group="Violencia" />
                <asp:RadioButton runat="server" ID="rbAntecedentePersonalViolenciaSi" GroupName="AntecedentePersonalViolencia"
                    CssClass="rbAntecedentePersonalViolenciaSi" alert-message="Ant. Personal: Violencia"
                    alert-group="Violencia" />
                <!-- Alergia medicamentos -->
                <asp:RadioButton runat="server" ID="rbAntecedentePersonalAlergiaMedicamentoNo" GroupName="AntecedentePersonalAlergiaMedicamento"
                    CssClass="rbAntecedentePersonalAlergiaMedicamentoNo" alert-group="AlergiaMedic" />
                <asp:RadioButton runat="server" ID="rbAntecedentePersonalAlergiaMedicamentoSi" GroupName="AntecedentePersonalAlergiaMedicamento"
                    CssClass="rbAntecedentePersonalAlergiaMedicamentoSi" alert-message="Ant. Personal: Alergia Medicamento"
                    alert-group="AlergiaMedic" />
                <!-- Observaciones -->
                <asp:TextBox runat="server" ID="txtAntecedentesObervaciones" CssClass="txtAntecedentesObervaciones textBoxchars"
                    ToolTip="Ingresar Otros Antecedentes"></asp:TextBox>
                <!-- Antecedentes Obstetricos -->
                <asp:TextBox runat="server" ID="txtGestasPrevias" Columns="2" CssClass="txtGestasPrevias textBox2chars"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtAbortos" Columns="2" CssClass="txtAbortos textBox2chars"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtEmbarazosEctopicos" Columns="2" CssClass="txtEmbarazosEctopicos textBox1chars"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtPartos" Columns="2" CssClass="txtPartos textBox2chars"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtPartosVaginales" Columns="2" CssClass="txtPartosVaginales textBox2chars"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtCesareas" Columns="1" CssClass="txtCesareas textBox1chars"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtNacidosVivos" Columns="2" CssClass="txtNacidosVivos textBox2chars"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtNacidosMuertos" Columns="1" CssClass="txtNacidosMuertos textBox1chars"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtViven" Columns="2" CssClass="txtViven textBox2chars"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtMuertosPrimerSemana" Columns="1" CssClass="txtMuertosPrimerSemana textBox1chars"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtMuertosDespuesPrimerSemana" Columns="1" CssClass="txtMuertosDespuesPrimerSemana textBox1chars"></asp:TextBox>
                <asp:RadioButton runat="server" ID="rbAbortos3Concecutivos" CssClass="rbAbortos3Concecutivos"
                    alert-message="3 Abortos expontáneos consecutivos" />
                <asp:RadioButton runat="server" ID="rbUltimoPrevioNoCorresponde" GroupName="UltimoPrevio"
                    CssClass="rbUltimoPrevioNoCorresponde" alert-group="UltimoPrevio" />
                <asp:RadioButton runat="server" ID="rbUltimoPrevioNormal" GroupName="UltimoPrevio"
                    CssClass="rbUltimoPrevioNormal" alert-group="UltimoPrevio" />
                <asp:RadioButton runat="server" ID="rbUltimoPrevioMenor2500" GroupName="UltimoPrevio"
                    CssClass="rbUltimoPrevioMenor2500" alert-message="Ultimo Previo < 2500 g" alert-group="UltimoPrevio" />
                <asp:RadioButton runat="server" ID="rbUltimoPrevioMayor4000" GroupName="UltimoPrevio"
                    CssClass="rbUltimoPrevioMayor4000" alert-message="Ultimo Previo 4000 g" alert-group="UltimoPrevio" />
                <asp:RadioButton runat="server" ID="rbAntecedentesGemelaresNo" GroupName="AntecedentesGemelares"
                    CssClass="rbAntecedentesGemelaresNo" alert-group="AntecedentesGemelares" />
                <asp:RadioButton runat="server" ID="rbAntecedentesGemelaresSi" GroupName="AntecedentesGemelares"
                    CssClass="rbAntecedentesGemelaresSi" alert-message="Antecedentes de Gemelares"
                    alert-group="AntecedentesGemelares" />
                <asp:TextBox runat="server" ID="txtFinEmbAnterior" CssClass="txtFinEmbAnterior textBoxSmallchars datepicker22"></asp:TextBox>
                <asp:RadioButton runat="server" ID="rbFinEmbAnteriorMenor1Año" CssClass="rbFinEmbAnteriorMenor1Año" />
                <asp:RadioButton runat="server" ID="rbEmbarazoPlaneadoNo" GroupName="EmbarazoPlaneado"
                    CssClass="rbEmbarazoPlaneadoNo" alert-message="Embarazo no Planeado" alert-group="EmbarazoPlaneado" />
                <asp:RadioButton runat="server" ID="rbEmbarazoPlaneadoSi" GroupName="EmbarazoPlaneado"
                    CssClass="rbEmbarazoPlaneadoSi" alert-group="EmbarazoPlaneado" />
                <!-- Metodos Anticonceptivos -->
                <asp:RadioButton runat="server" ID="rbFracMetAnticonceptivoNoUsaba" GroupName="FracMetAnticonceptivo"
                    CssClass="rbFracMetAnticonceptivoNoUsaba" />
                <asp:RadioButton runat="server" ID="rbFracMetAnticonceptivoBarrera" GroupName="FracMetAnticonceptivo"
                    CssClass="rbFracMetAnticonceptivoBarrera" alert-message="Fracaso método Anticoncep Barrera" />
                <asp:RadioButton runat="server" ID="rbFracMetAnticonceptivoDIU" GroupName="FracMetAnticonceptivo"
                    CssClass="rbFracMetAnticonceptivoDIU" alert-message="Fracaso método Anticoncep DUI" />
                <asp:RadioButton runat="server" ID="rbFracMetAnticonceptivoHormonal" GroupName="FracMetAnticonceptivo"
                    CssClass="rbFracMetAnticonceptivoHormonal" alert-message="Fracaso método Anticoncep Hormonal" />
                <asp:RadioButton runat="server" ID="rbFracMetAnticonceptivoEmergencia" GroupName="FracMetAnticonceptivo"
                    CssClass="rbFracMetAnticonceptivoEmergencia" alert-message="Fracaso método Anticoncep Emergencia" />
                <asp:RadioButton runat="server" ID="rbFracMetAnticonceptivoNatural" GroupName="FracMetAnticonceptivo"
                    CssClass="rbFracMetAnticonceptivoNatural" alert-message="Fracaso método Anticoncep Natural" />
                <!-- Gestación actual -->
                <!-- Peso anterior -->
                <asp:TextBox runat="server" ID="txtPesoAnterior"  Columns="5" CssClass="txtPesoAnterior textBox3Smallchars"  max="200" min="40"
                    ToolTip="Ingresar Peso"></asp:TextBox>
                <!-- Talla -->
                <asp:TextBox runat="server" ID="txtTalla" type="number" Columns="2" CssClass="txtTalla textBox3Smallchars" required max="220" min="100"
                    ToolTip="Ingresar número sin puntos ni coma"></asp:TextBox>
                <!-- FUM -->

                <asp:TextBox runat="server" ID="txtFUM" CssClass="txtFUM textBoxSmallchars datepicker22"></asp:TextBox>
                <!-- FPP -->
                <asp:TextBox runat="server" ID="txtFPP" CssClass="txtFPP textBoxSmallchars datepicker22"></asp:TextBox>
                <!-- EG confiable? -->
                <asp:RadioButton runat="server" ID="rbEGConfiableFUMNo" GroupName="EGConfiableFUM"
                    CssClass="rbEGConfiableFUMNo" alert-message="E. Gestacional No Confiable Fum" />
                <asp:RadioButton runat="server" ID="rbEGConfiableFUMSi" GroupName="EGConfiableFUM"
                    CssClass="rbEGConfiableFUMSi" />
                <asp:RadioButton runat="server" ID="rbEGConfiableEco20No" GroupName="EGConfiableEco20"
                    CssClass="rbEGConfiableEco20No" alert-message="E. Gestacional No Confiable Eco" />
                <asp:RadioButton runat="server" ID="rbEGConfiableEco20Si" GroupName="EGConfiableEco20"
                    CssClass="rbEGConfiableEco20Si" />
                <!-- Fumadora activa? -->
                <asp:RadioButton runat="server" ID="rbFumaActiva1TrimNo" GroupName="FumaActiva1Trim"
                    CssClass="rbFumaActiva1TrimNo" />
                <asp:RadioButton runat="server" ID="rbFumaActiva1TrimSi" GroupName="FumaActiva1Trim"
                    CssClass="rbFumaActiva1TrimSi" alert-message="Fumadora Activa 1º T." />
                <asp:RadioButton runat="server" ID="rbFumaActiva2TrimNo" GroupName="FumaActiva2Trim"
                    CssClass="rbFumaActiva2TrimNo" />
                <asp:RadioButton runat="server" ID="rbFumaActiva2TrimSi" GroupName="FumaActiva2Trim"
                    CssClass="rbFumaActiva2TrimSi" alert-message="Fumadora Activa 2º T." />
                <asp:RadioButton runat="server" ID="rbFumaActiva3TrimNo" GroupName="FumaActiva3Trim"
                    CssClass="rbFumaActiva3TrimNo" />
                <asp:RadioButton runat="server" ID="rbFumaActiva3TrimSi" GroupName="FumaActiva3Trim"
                    CssClass="rbFumaActiva3TrimSi" alert-message="Fumadora Activa 3º T." />
                <!-- Fumadora pasiva? -->
                <asp:RadioButton runat="server" ID="rbFumaPasiva1TrimNo" GroupName="FumaPasiva1Trim"
                    CssClass="rbFumaPasiva1TrimNo" />
                <asp:RadioButton runat="server" ID="rbFumaPasiva1TrimSi" GroupName="FumaPasiva1Trim"
                    CssClass="rbFumaPasiva1TrimSi" alert-message="Fumadora Pasiva 1º T." />
                <asp:RadioButton runat="server" ID="rbFumaPasiva2TrimNo" GroupName="FumaPasiva2Trim"
                    CssClass="rbFumaPasiva2TrimNo" />
                <asp:RadioButton runat="server" ID="rbFumaPasiva2TrimSi" GroupName="FumaPasiva2Trim"
                    CssClass="rbFumaPasiva2TrimSi" alert-message="Fumadora Pasiva 2º T." />
                <asp:RadioButton runat="server" ID="rbFumaPasiva3TrimNo" GroupName="FumaPasiva3Trim"
                    CssClass="rbFumaPasiva3TrimNo" />
                <asp:RadioButton runat="server" ID="rbFumaPasiva3TrimSi" GroupName="FumaPasiva3Trim"
                    CssClass="rbFumaPasiva3TrimSi" alert-message="Fumadora Pasiva 3º T." />
                <!-- Drogas? -->
                <asp:RadioButton runat="server" ID="rbDrogas1TrimNo" GroupName="Drogas1Trim" CssClass="rbDrogas1TrimNo" />
                <asp:RadioButton runat="server" ID="rbDrogas1TrimSi" GroupName="Drogas1Trim" CssClass="rbDrogas1TrimSi"
                    alert-message="Consume drogas 1º T." />
                <asp:RadioButton runat="server" ID="rbDrogas2TrimNo" GroupName="Drogas2Trim" CssClass="rbDrogas2TrimNo" />
                <asp:RadioButton runat="server" ID="rbDrogas2TrimSi" GroupName="Drogas2Trim" CssClass="rbDrogas2TrimSi"
                    alert-message="Consume drogas 1º T." />
                <asp:RadioButton runat="server" ID="rbDrogas3TrimNo" GroupName="Drogas3Trim" CssClass="rbDrogas3TrimNo" />
                <asp:RadioButton runat="server" ID="rbDrogas3TrimSi" GroupName="Drogas3Trim" CssClass="rbDrogas3TrimSi"
                    alert-message="Consume drogas 3º T." />
                <!-- Alcohol? -->
                <asp:RadioButton runat="server" ID="rbAlcohol1TrimNo" GroupName="Alcohol1Trim" CssClass="rbAlcohol1TrimNo" />
                <asp:RadioButton runat="server" ID="rbAlcohol1TrimSi" GroupName="Alcohol1Trim" CssClass="rbAlcohol1TrimSi"
                    alert-message="Consume Alcohol 1º T." />
                <asp:RadioButton runat="server" ID="rbAlcohol2TrimNo" GroupName="Alcohol2Trim" CssClass="rbAlcohol2TrimNo" />
                <asp:RadioButton runat="server" ID="rbAlcohol2TrimSi" GroupName="Alcohol2Trim" CssClass="rbAlcohol2TrimSi"
                    alert-message="Consume Alcohol 2º T." />
                <asp:RadioButton runat="server" ID="rbAlcohol3TrimNo" GroupName="Alcohol3Trim" CssClass="rbAlcohol3TrimNo" />
                <asp:RadioButton runat="server" ID="rbAlcohol3TrimSi" GroupName="Alcohol3Trim" CssClass="rbAlcohol3TrimSi"
                    alert-message="Consume Alcohol 3º T." />
                <!-- Violencia? -->
                <asp:RadioButton runat="server" ID="rbViolencia1TrimNo" GroupName="Violencia1Trim"
                    CssClass="rbViolencia1TrimNo" />
                <asp:RadioButton runat="server" ID="rbViolencia1TrimSi" GroupName="Violencia1Trim"
                    CssClass="rbViolencia1TrimSi" alert-message="Violencia 1º T." />
                <asp:RadioButton runat="server" ID="rbViolencia2TrimNo" GroupName="Violencia2Trim"
                    CssClass="rbViolencia2TrimNo" />
                <asp:RadioButton runat="server" ID="rbViolencia2TrimSi" GroupName="Violencia2Trim"
                    CssClass="rbViolencia2TrimSi" alert-message="Violencia 2º T." />
                <asp:RadioButton runat="server" ID="rbViolencia3TrimNo" GroupName="Violencia3Trim"
                    CssClass="rbViolencia3TrimNo" />
                <asp:RadioButton runat="server" ID="rbViolencia3TrimSi" GroupName="Violencia3Trim"
                    CssClass="rbViolencia3TrimSi" alert-message="Violencia 3º T." />
                <!-- Antirubeola -->
                <asp:RadioButton runat="server" ID="rbAntirubeolaPrevia" GroupName="Antirubeola"
                    CssClass="rbAntirubeolaPrevia" />
                <asp:RadioButton runat="server" ID="rbAntirubeolaNoSabe" GroupName="Antirubeola"
                    CssClass="rbAntirubeolaNoSabe" alert-message="Antirubeola No Sabe" />
                <asp:RadioButton runat="server" ID="rbAntirubeolaEmbarazo" GroupName="Antirubeola"
                    CssClass="rbAntirubeolaEmbarazo" alert-message="Antirubeola Embarazo" />
                <asp:RadioButton runat="server" ID="rbAntirubeolaNo" GroupName="Antirubeola" CssClass="rbAntirubeolaNo"
                    alert-message="Antirubeola NO" />
                <!-- Antitetanica -->
                <asp:RadioButton runat="server" ID="rbAntitetanicaVigenteSi" GroupName="AntitetanicaVigente"
                    CssClass="rbAntitetanicaVigenteSi" />
                <asp:RadioButton runat="server" ID="rbAntitetanicaVigenteNo" GroupName="AntitetanicaVigente"
                    CssClass="rbAntitetanicaVigenteNo" alert-message="No posee Antitetánica" />
                <asp:TextBox runat="server" ID="txtAntitetanicaDosis1" Columns="1" CssClass="txtAntitetanicaDosis1 textBox1chars"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtAntitetanicaDosis2" Columns="1" CssClass="txtAntitetanicaDosis2 textBox1chars"></asp:TextBox>
                <!-- Ex Normal -->
                <asp:RadioButton runat="server" ID="rbExNormalOdontNo" GroupName="ExNormalOdont"
                    CssClass="rbExNormalOdontNo" alert-message="Examen Odonto No Normal" />
                <asp:RadioButton runat="server" ID="rbExNormalOdontSi" GroupName="ExNormalOdont"
                    CssClass="rbExNormalOdontSi" />
                <asp:RadioButton runat="server" ID="rbExNormalMamasNo" GroupName="ExNormalMamas"
                    CssClass="rbExNormalMamasNo" alert-message="Examen Mamas No Normal" />
                <asp:RadioButton runat="server" ID="rbExNormalMamasSi" GroupName="ExNormalMamas"
                    CssClass="rbExNormalMamasSi" />
                <!-- Cervix -->
                <asp:RadioButton runat="server" ID="rbCervixVisualNormal" GroupName="CervixVisual"
                    CssClass="rbCervixVisualNormal" />
                <asp:RadioButton runat="server" ID="rbCervixVisualANormal" GroupName="CervixVisual"
                    CssClass="rbCervixVisualANormal" />
                <asp:RadioButton runat="server" ID="rbCervixVisualNoSeHizo" GroupName="CervixVisual"
                    CssClass="rbCervixVisualNoSeHizo" />
                <asp:RadioButton runat="server" ID="rbCervixPAPNormal" GroupName="CervixPAP" CssClass="rbCervixPAPNormal" />
                <asp:RadioButton runat="server" ID="rbCervixPAPANormal" GroupName="CervixPAP" CssClass="rbCervixPAPANormal" />
                <asp:RadioButton runat="server" ID="rbCervixPAPNoSeHizo" GroupName="CervixPAP" CssClass="rbCervixPAPNoSeHizo" />
                <asp:RadioButton runat="server" ID="rbCervixCOLPNormal" GroupName="CervixCOLP" CssClass="rbCervixCOLPNormal" />
                <asp:RadioButton runat="server" ID="rbCervixCOLPANormal" GroupName="CervixCOLP" CssClass="rbCervixCOLPANormal" />
                <asp:RadioButton runat="server" ID="rbCervixCOLPNoSeHizo" GroupName="CervixCOLP"
                    CssClass="rbCervixCOLPNoSeHizo" />
                <!-- ¿Sangre? -->
                <asp:TextBox runat="server" ID="txtGrupo" CssClass="txtGrupo textBox2chars"></asp:TextBox>
                <asp:RadioButton runat="server" ID="rbSangreRhPositivo" GroupName="SangreRh" CssClass="rbSangreRhPositivo" />
                <asp:RadioButton runat="server" ID="rbSangreRhNegativo" GroupName="SangreRh" CssClass="rbSangreRhNegativo" />
                <asp:RadioButton runat="server" ID="rbSangreInmunizSi" GroupName="SangreInmuniz"
                    CssClass="rbSangreInmunizSi" />
                <asp:RadioButton runat="server" ID="rbSangreInmunizNo" GroupName="SangreInmuniz"
                    CssClass="rbSangreInmunizNo" />
                <asp:RadioButton runat="server" ID="rbSangreGlobulinaAntiDNo" GroupName="SangreGlobulinaAntiD"
                    CssClass="rbSangreGlobulinaAntiDNo" />
                <asp:RadioButton runat="server" ID="rbSangreGlobulinaAntiDSi" GroupName="SangreGlobulinaAntiD"
                    CssClass="rbSangreGlobulinaAntiDSi" />
                <asp:RadioButton runat="server" ID="rbSangreGlobulinaAntiDNC" GroupName="SangreGlobulinaAntiD"
                    CssClass="rbSangreGlobulinaAntiDNC" />
                <!-- Toxoplasmosis -->
                <asp:RadioButton runat="server" ID="rbToxoplasmosisMenos20IgGNegativo" GroupName="ToxoplasmosisMenos20IgG"
                    CssClass="rbToxoplasmosisMenos20IgGNegativo" />
                <asp:RadioButton runat="server" ID="rbToxoplasmosisMenos20IgGPositivo" GroupName="ToxoplasmosisMenos20IgG"
                    CssClass="rbToxoplasmosisMenos20IgGPositivo" />
                <asp:RadioButton runat="server" ID="rbToxoplasmosisMenos20IgGNoSeHizo" GroupName="ToxoplasmosisMenos20IgG"
                    CssClass="rbToxoplasmosisMenos20IgGNoSeHizo" />
                <asp:RadioButton runat="server" ID="rbToxoplasmosisMas20IgGNegativo" GroupName="ToxoplasmosisMas20IgG"
                    CssClass="rbToxoplasmosisMas20IgGNegativo" />
                <asp:RadioButton runat="server" ID="rbToxoplasmosisMas20IgGPositivo" GroupName="ToxoplasmosisMas20IgG"
                    CssClass="rbToxoplasmosisMas20IgGPositivo" />
                <asp:RadioButton runat="server" ID="rbToxoplasmosisMas20IgGNoSeHizo" GroupName="ToxoplasmosisMas20IgG"
                    CssClass="rbToxoplasmosisMas20IgGNoSeHizo" />
                <asp:RadioButton runat="server" ID="rbToxoplasmosis1ConsultaIgMNegativo" GroupName="Toxoplasmosis1ConsultaIgM"
                    CssClass="rbToxoplasmosis1ConsultaIgMNegativo" />
                <asp:RadioButton runat="server" ID="rbToxoplasmosis1ConsultaIgMPositivo" GroupName="Toxoplasmosis1ConsultaIgM"
                    CssClass="rbToxoplasmosis1ConsultaIgMPositivo" />
                <asp:RadioButton runat="server" ID="rbToxoplasmosis1ConsultaIgMNoSeHizo" GroupName="Toxoplasmosis1ConsultaIgM"
                    CssClass="rbToxoplasmosis1ConsultaIgMNoSeHizo" />
                <!-- VIH -->
                <asp:RadioButton runat="server" ID="rbVIHCRNo" GroupName="rbVIHCR" CssClass="rbVIHCRNo" />
                <asp:RadioButton runat="server" ID="rbVIHCRSi" GroupName="rbVIHCR" CssClass="rbVIHCRSi" />
                <!-- VIH Primer Muestra -->
                <div class="divDatePopUp divVIHPrimerMuestra">
                    <asp:RadioButton runat="server" ID="rbVIHPrimerMuestraSolicitadoNo" GroupName="VIHPrimerMuestraSolicitado"
                        CssClass="rbVIHSolicitadoNo" />
                    <asp:RadioButton runat="server" ID="rbVIHPrimerMuestraSolicitadoSi" GroupName="VIHPrimerMuestraSolicitado"
                        CssClass="rbVIHSolicitadoSi" />
                    <asp:RadioButton runat="server" ID="rbVIHPrimerMuestraRealizadoNo" GroupName="VIHPrimerMuestraRealizado"
                        CssClass="rbVIHRealizadoNo" />
                    <asp:RadioButton runat="server" ID="rbVIHPrimerMuestraRealizadoSi" GroupName="VIHPrimerMuestraRealizado"
                        CssClass="rbVIHRealizadoSi" />
                    <asp:TextBox runat="server" ID="txtVIHPrimerMuestraFecha" CssClass="txtVIHFecha textBoxSmallchars"></asp:TextBox>
                </div>
                <!-- VIH Segunda Muestra -->
                <div class="divDatePopUp divVIHSegundaMuestra">
                    <asp:RadioButton runat="server" ID="rbVIHSegundaMuestraSolicitadoNo" GroupName="VIHSegundaMuestraSolicitado"
                        CssClass="rbVIHSolicitadoNo" />
                    <asp:RadioButton runat="server" ID="rbVIHSegundaMuestraSolicitadoSi" GroupName="VIHSegundaMuestraSolicitado"
                        CssClass="rbVIHSolicitadoSi" />
                    <asp:RadioButton runat="server" ID="rbVIHSegundaMuestraRealizadoNo" GroupName="VIHSegundaMuestraRealizado"
                        CssClass="rbVIHRealizadoNo" />
                    <asp:RadioButton runat="server" ID="rbVIHSegundaMuestraRealizadoSi" GroupName="VIHSegundaMuestraRealizado"
                        CssClass="rbVIHRealizadoSi" />
                    <asp:TextBox runat="server" ID="txtVIHSegundaMuestraFecha" CssClass="txtVIHFecha textBoxSmallchars"></asp:TextBox>
                </div>
                <!-- VIH Tercer Muestra -->
                <div class="divDatePopUp divVIHTercerMuestra">
                    <asp:RadioButton runat="server" ID="rbVIHTercerMuestraSolicitadoNo" GroupName="VIHTercerMuestraSolicitado"
                        CssClass="rbVIHSolicitadoNo" />
                    <asp:RadioButton runat="server" ID="rbVIHTercerMuestraSolicitadoSi" GroupName="VIHTercerMuestraSolicitado"
                        CssClass="rbVIHSolicitadoSi" />
                    <asp:RadioButton runat="server" ID="rbVIHTercerMuestraRealizadoNo" GroupName="VIHTercerMuestraRealizado"
                        CssClass="rbVIHRealizadoNo" />
                    <asp:RadioButton runat="server" ID="rbVIHTercerMuestraRealizadoSi" GroupName="VIHTercerMuestraRealizado"
                        CssClass="rbVIHRealizadoSi" />
                    <asp:TextBox runat="server" ID="txtVIHTercerMuestraFecha" CssClass="txtVIHFecha textBoxSmallchars"></asp:TextBox>
                </div>
                <!-- Hemoglobina Menos 20 semanas -->
                <asp:TextBox runat="server" ID="txtHBMenos20" CssClass="txtHBMenos20 textBoxchars" ToolTip="Ingrese un valor decimal con punto o coma."></asp:TextBox>
                <asp:RadioButton runat="server" ID="rbHemoglobinaMenos20Menor11" GroupName="HemoglobinaMenos20Menor11"
                    CssClass="rbHemoglobinaMenos20Menor11" />
                <!-- Hierro/Folatos Indicados -->
                <asp:RadioButton runat="server" ID="rbHierroIndicadoNo" GroupName="HierroIndicado"
                    CssClass="rbHierroIndicadoNo" />
                <asp:RadioButton runat="server" ID="rbHierroIndicadoSi" GroupName="HierroIndicado"
                    CssClass="rbHierroIndicadoSi" />
                <asp:RadioButton runat="server" ID="rbFolatosIndicadosNo" GroupName="FolatosIndicados"
                    CssClass="rbFolatosIndicadosNo" />
                <asp:RadioButton runat="server" ID="rbFolatosIndicadosSi" GroupName="FolatosIndicados"
                    CssClass="rbFolatosIndicadosSi" />
                <!-- Hemoglobina Mas 20 semanas -->
                <asp:TextBox runat="server" ID="txtHBMas20" CssClass="txtHBMas20 textBoxchars" ToolTip="Ingrese un valor decimal con punto o coma."></asp:TextBox>
                <asp:RadioButton runat="server" ID="rbHemoglobinaMas20Menor11" GroupName="HemoglobinaMas20Menor11"
                    CssClass="rbHemoglobinaMas20Menor11" />
                <!-- Sifilis -->
                <!-- Prueba no treponemica -->
                <div class="divSifilisPNTPopUp divSifilisPruebaNTPrimerMuestra">
                    <asp:RadioButton runat="server" ID="rbSifilisPruebaNTPrimerMuestraNegativo" GroupName="SifilisPruebaNTPrimerMuestra"
                        CssClass="rbSifilisPruebaNTNegativo" />
                    <asp:RadioButton runat="server" ID="rbSifilisPruebaNTPrimerMuestraPositivo" GroupName="SifilisPruebaNTPrimerMuestra"
                        CssClass="rbSifilisPruebaNTPositivo" />
                    <asp:RadioButton runat="server" ID="rbSifilisPruebaNTPrimerMuestraSD" GroupName="SifilisPruebaNTPrimerMuestra"
                        CssClass="rbSifilisPruebaNTSD" />
                    <asp:TextBox runat="server" ID="txtSifilisPruebaNTPrimerMuestraFecha" CssClass="txtSifilisPNTFecha textBoxSmallchars"></asp:TextBox>
                </div>
                <div class="divSifilisPNTPopUp divSifilisPruebaNTSegundaMuestra">
                    <asp:RadioButton runat="server" ID="rbSifilisPruebaNTSegundaMuestraNegativo" GroupName="SifilisPruebaNTSegundaMuestra"
                        CssClass="rbSifilisPruebaNTNegativo" />
                    <asp:RadioButton runat="server" ID="rbSifilisPruebaNTSegundaMuestraPositivo" GroupName="SifilisPruebaNTSegundaMuestra"
                        CssClass="rbSifilisPruebaNTPositivo" />
                    <asp:RadioButton runat="server" ID="rbSifilisPruebaNTSegundaMuestraSD" GroupName="SifilisPruebaNTSegundaMuestra"
                        CssClass="rbSifilisPruebaNTSD" />
                    <asp:TextBox runat="server" ID="txtSifilisPruebaNTSegundaMuestraFecha" CssClass="txtSifilisPNTFecha textBoxSmallchars"></asp:TextBox>
                </div>
                <div class="divSifilisPNTPopUp divSifilisPruebaNTTercerMuestra">
                    <asp:RadioButton runat="server" ID="rbSifilisPruebaNTTercerMuestraNegativo" GroupName="SifilisPruebaNTTercerMuestra"
                        CssClass="rbSifilisPruebaNTNegativo" />
                    <asp:RadioButton runat="server" ID="rbSifilisPruebaNTTercerMuestraPositivo" GroupName="SifilisPruebaNTTercerMuestra"
                        CssClass="rbSifilisPruebaNTPositivo" />
                    <asp:RadioButton runat="server" ID="rbSifilisPruebaNTTercerMuestraSD" GroupName="SifilisPruebaNTTercerMuestra"
                        CssClass="rbSifilisPruebaNTSD" />
                    <asp:TextBox runat="server" ID="txtSifilisPruebaNTTercerMuestraFecha" CssClass="txtSifilisPNTFecha textBoxSmallchars"></asp:TextBox>
                </div>
                <!-- Prueba treponemica -->
                <div class="divSifilisPTPopUp divSifilisPruebaTPrimerMuestra">
                    <asp:RadioButton runat="server" ID="rbSifilisPruebaTPrimerMuestraNegativo" GroupName="SifilisPruebaTPrimerMuestra"
                        CssClass="rbSifilisPruebaTNegativo" />
                    <asp:RadioButton runat="server" ID="rbSifilisPruebaTPrimerMuestraPositivo" GroupName="SifilisPruebaTPrimerMuestra"
                        CssClass="rbSifilisPruebaTPositivo" />
                    <asp:RadioButton runat="server" ID="rbSifilisPruebaTPrimerMuestraSD" GroupName="SifilisPruebaTPrimerMuestra"
                        CssClass="rbSifilisPruebaTSD" />
                    <asp:RadioButton runat="server" ID="rbSifilisPruebaTPrimerMuestraNC" GroupName="SifilisPruebaTPrimerMuestra"
                        CssClass="rbSifilisPruebaTNC" />
                    <asp:TextBox runat="server" ID="txtSifilisPruebaTPrimerMuestraFecha" CssClass="txtSifilisPTFecha textBoxSmallchars"></asp:TextBox>
                </div>
                <div class="divSifilisPTPopUp divSifilisPruebaTSegundaMuestra">
                    <asp:RadioButton runat="server" ID="rbSifilisPruebaTSegundaMuestraNegativo" GroupName="SifilisPruebaTSegundaMuestra"
                        CssClass="rbSifilisPruebaTNegativo" />
                    <asp:RadioButton runat="server" ID="rbSifilisPruebaTSegundaMuestraPositivo" GroupName="SifilisPruebaTSegundaMuestra"
                        CssClass="rbSifilisPruebaTPositivo" />
                    <asp:RadioButton runat="server" ID="rbSifilisPruebaTSegundaMuestraSD" GroupName="SifilisPruebaTSegundaMuestra"
                        CssClass="rbSifilisPruebaTSD" />
                    <asp:RadioButton runat="server" ID="rbSifilisPruebaTSegundaMuestraNC" GroupName="SifilisPruebaTSegundaMuestra"
                        CssClass="rbSifilisPruebaTNC" />
                    <asp:TextBox runat="server" ID="txtSifilisPruebaTSegundaMuestraFecha" CssClass="txtSifilisPTFecha textBoxSmallchars"></asp:TextBox>
                </div>
                <div class="divSifilisPTPopUp divSifilisPruebaTTercerMuestra">
                    <asp:RadioButton runat="server" ID="rbSifilisPruebaTTercerMuestraNegativo" GroupName="SifilisPruebaTTercerMuestra"
                        CssClass="rbSifilisPruebaTNegativo" />
                    <asp:RadioButton runat="server" ID="rbSifilisPruebaTTercerMuestraPositivo" GroupName="SifilisPruebaTTercerMuestra"
                        CssClass="rbSifilisPruebaTPositivo" />
                    <asp:RadioButton runat="server" ID="rbSifilisPruebaTTercerMuestraSD" GroupName="SifilisPruebaTTercerMuestra"
                        CssClass="rbSifilisPruebaTSD" />
                    <asp:RadioButton runat="server" ID="rbSifilisPruebaTTercerMuestraNC" GroupName="SifilisPruebaTTercerMuestra"
                        CssClass="rbSifilisPruebaTNC" />
                    <asp:TextBox runat="server" ID="txtSifilisPruebaTTercerMuestraFecha" CssClass="txtSifilisPTFecha textBoxSmallchars"></asp:TextBox>
                </div>
                <!-- Tratamiento -->
                <div class="divSifilisTRATPopUp divSifilisTratamientoPrimerMuestra">
                    <asp:RadioButton runat="server" ID="rbSifilisTratamientoPrimerMuestraNo" GroupName="SifilisTratamientoPrimerMuestra"
                        CssClass="rbSifilisTratamientoNO" />
                    <asp:RadioButton runat="server" ID="rbSifilisTratamientoPrimerMuestraSi" GroupName="SifilisTratamientoPrimerMuestra"
                        CssClass="rbSifilisTratamientoSi" />
                    <asp:RadioButton runat="server" ID="rbSifilisTratamientoPrimerMuestraSD" GroupName="SifilisTratamientoPrimerMuestra"
                        CssClass="rbSifilisTratamientoSD" />
                    <asp:RadioButton runat="server" ID="rbSifilisTratamientoPrimerMuestraNC" GroupName="SifilisTratamientoPrimerMuestra"
                        CssClass="rbSifilisTratamientoNC" />
                    <asp:TextBox runat="server" ID="txtSifilisTratamientoPrimerMuestraFecha" CssClass="txtSifilisTratamientoFecha textBoxSmallchars"></asp:TextBox>
                </div>
                <div class="divSifilisTRATPopUp divSifilisTratamientoSegundaMuestra">
                    <asp:RadioButton runat="server" ID="rbSifilisTratamientoSegundaMuestraNo" GroupName="SifilisTratamientoSegundaMuestra"
                        CssClass="rbSifilisTratamientoNO" />
                    <asp:RadioButton runat="server" ID="rbSifilisTratamientoSegundaMuestraSi" GroupName="SifilisTratamientoSegundaMuestra"
                        CssClass="rbSifilisTratamientoSi" />
                    <asp:RadioButton runat="server" ID="rbSifilisTratamientoSegundaMuestraSD" GroupName="SifilisTratamientoSegundaMuestra"
                        CssClass="rbSifilisTratamientoSD" />
                    <asp:RadioButton runat="server" ID="rbSifilisTratamientoSegundaMuestraNC" GroupName="SifilisTratamientoSegundaMuestra"
                        CssClass="rbSifilisTratamientoNC" />
                    <asp:TextBox runat="server" ID="txtSifilisTratamientoSegundaMuestraFecha" CssClass="txtSifilisTratamientoFecha textBoxSmallchars"></asp:TextBox>
                </div>
                <div class="divSifilisTRATPopUp divSifilisTratamientoTercerMuestra">
                    <asp:RadioButton runat="server" ID="rbSifilisTratamientoTercerMuestraNo" GroupName="SifilisTratamientoTercerMuestra"
                        CssClass="rbSifilisTratamientoNO" />
                    <asp:RadioButton runat="server" ID="rbSifilisTratamientoTercerMuestraSi" GroupName="SifilisTratamientoTercerMuestra"
                        CssClass="rbSifilisTratamientoSi" />
                    <asp:RadioButton runat="server" ID="rbSifilisTratamientoTercerMuestraSD" GroupName="SifilisTratamientoTercerMuestra"
                        CssClass="rbSifilisTratamientoSD" />
                    <asp:RadioButton runat="server" ID="rbSifilisTratamientoTercerMuestraNC" GroupName="SifilisTratamientoTercerMuestra"
                        CssClass="rbSifilisTratamientoNC" />
                    <asp:TextBox runat="server" ID="txtSifilisTratamientoTercerMuestraFecha" CssClass="txtSifilisTratamientoFecha textBoxSmallchars"></asp:TextBox>
                </div>
                <asp:RadioButton runat="server" ID="rbSifilisParejaMenos20No" GroupName="SifilisParejaMenos20"
                    CssClass="rbSifilisParejaMenos20No" />
                <asp:RadioButton runat="server" ID="rbSifilisParejaMenos20Si" GroupName="SifilisParejaMenos20"
                    CssClass="rbSifilisParejaMenos20Si" />
                <asp:RadioButton runat="server" ID="rbSifilisParejaMenos20SD" GroupName="SifilisParejaMenos20"
                    CssClass="rbSifilisParejaMenos20SD" />
                <asp:RadioButton runat="server" ID="rbSifilisParejaMenos20NC" GroupName="SifilisParejaMenos20"
                    CssClass="rbSifilisParejaMenos20NC" />
                <asp:RadioButton runat="server" ID="rbSifilisParejaMas20No" GroupName="SifilisParejaMas20"
                    CssClass="rbSifilisParejaMas20No" />
                <asp:RadioButton runat="server" ID="rbSifilisParejaMas20Si" GroupName="SifilisParejaMas20"
                    CssClass="rbSifilisParejaMas20Si" />
                <asp:RadioButton runat="server" ID="rbSifilisParejaMas20SD" GroupName="SifilisParejaMas20"
                    CssClass="rbSifilisParejaMas20SD" />
                <asp:RadioButton runat="server" ID="rbSifilisParejaMas20NC" GroupName="SifilisParejaMas20"
                    CssClass="rbSifilisParejaMas20NC" />
                <!-- Chagas -->
                <asp:RadioButton runat="server" ID="rbChagasNegativo" GroupName="Chagas" CssClass="rbChagasNegativo" />
                <asp:RadioButton runat="server" ID="rbChagasPositivo" GroupName="Chagas" CssClass="rbChagasPositivo" />
                <asp:RadioButton runat="server" ID="rbChagasNoSeHizo" GroupName="Chagas" CssClass="rbChagasNoSeHizo" />
                <!-- Hepatitis B -->
                <asp:RadioButton runat="server" ID="rbHepatitisBNegativo" GroupName="HepatitisB"
                    CssClass="rbHepatitisBNegativo" />
                <asp:RadioButton runat="server" ID="rbHepatitisBPositivo" GroupName="HepatitisB"
                    CssClass="rbHepatitisBPositivo" />
                <asp:RadioButton runat="server" ID="rbHepatitisBNoSeHizo" GroupName="HepatitisB"
                    CssClass="rbHepatitisBNoSeHizo" />
                <!-- Bacteriuria -->
                <asp:RadioButton runat="server" ID="rbBacteriuriaMenos20Normal" GroupName="BacteriuriaMenos20"
                    CssClass="rbBacteriuriaMenos20Normal" />
                <asp:RadioButton runat="server" ID="rbBacteriuriaMenos20Anormal" GroupName="BacteriuriaMenos20"
                    CssClass="rbBacteriuriaMenos20Anormal" />
                <asp:RadioButton runat="server" ID="rbBacteriuriaMenos20NoSeHizo" GroupName="BacteriuriaMenos20"
                    CssClass="rbBacteriuriaMenos20NoSeHizo" />
                <asp:RadioButton runat="server" ID="rbBacteriuriaMas20Normal" GroupName="BacteriuriaMas20"
                    CssClass="rbBacteriuriaMas20Normal" />
                <asp:RadioButton runat="server" ID="rbBacteriuriaMas20Anormal" GroupName="BacteriuriaMas20"
                    CssClass="rbBacteriuriaMas20Anormal" />
                <asp:RadioButton runat="server" ID="rbBacteriuriaMas20NoSeHizo" GroupName="BacteriuriaMas20"
                    CssClass="rbBacteriuriaMas20NoSeHizo" />
                <!-- Glucemia en ayunas -->
                <asp:TextBox runat="server" ID="txtGlucemiaMenos20Valor" CssClass="validate[custom[number],min[00],max[300]] txtGlucemiaMenos20Valor textBox3chars"></asp:TextBox>
                <asp:RadioButton runat="server" ID="rbGlucemiaMenos20Mayor105" GroupName="GlucemiaMenos20Mayor105"
                    CssClass="rbGlucemiaMenos20Mayor105" />
                <asp:TextBox runat="server" ID="txtGlucemiaMas30Valor" CssClass="txtGlucemiaMas30Valor textBox3chars"></asp:TextBox>
                <asp:RadioButton runat="server" ID="rbGlucemiaMas30Mayor105" GroupName="GlucemiaMas30Mayor105"
                    CssClass="rbGlucemiaMas30Mayor105" />
                <!-- Estreptococo B -->
                <asp:RadioButton runat="server" ID="rbEstreptococoBNegativo" GroupName="EstreptococoB"
                    CssClass="rbEstreptococoBNegativo" />
                <asp:RadioButton runat="server" ID="rbEstreptococoBPositivo" GroupName="EstreptococoB"
                    CssClass="rbEstreptococoBPositivo" />
                <asp:RadioButton runat="server" ID="rbEstreptococoBNoSeHizo" GroupName="EstreptococoB"
                    CssClass="rbEstreptococoBNoSeHizo" />
                <!-- Preparación para el parto -->
                <asp:RadioButton runat="server" ID="rbPreparacionPartoNo" GroupName="PreparacionParto"
                    CssClass="rbPreparacionPartoNo" />
                <asp:RadioButton runat="server" ID="rbPreparacionPartoSi" GroupName="PreparacionParto"
                    CssClass="rbPreparacionPartoSi" />
                <!-- Consejería lactancia materna -->
                <asp:RadioButton runat="server" ID="rbConsejeriaLactanciaNo" GroupName="ConsejeriaLactancia"
                    CssClass="rbConsejeriaLactanciaNo" />
                <asp:RadioButton runat="server" ID="rbConsejeriaLactanciaSi" GroupName="ConsejeriaLactancia"
                    CssClass="rbConsejeriaLactanciaSi" />
            </div>
            <!-- datos extra del SIP -->
            <div id="sipExtraContainer">
                <!-- Antecedentes Gineco Obstetricos: Antecedentes-->
                <asp:RadioButton runat="server" ID="rbAgoAntecedenteEclampsiaNo" GroupName="rbAgoAntecedenteEclampsia"
                    CssClass="rbAgoAntecedenteEclampsiaNo" />
                <asp:RadioButton runat="server" ID="rbAgoAntecedenteEclampsiaSi" GroupName="rbAgoAntecedenteEclampsia"
                    CssClass="rbAgoAntecedenteEclampsiaSi" />
                <asp:RadioButton runat="server" ID="rbAgoAntecedentePreeclampsiaNo" GroupName="rbAgoAntecedentePreeclampsia"
                    CssClass="rbAgoAntecedentePreeclampsiaNo" />
                <asp:RadioButton runat="server" ID="rbAgoAntecedentePreeclampsiaSi" GroupName="rbAgoAntecedentePreeclampsia"
                    CssClass="rbAgoAntecedentePreeclampsiaSi" />
                <asp:RadioButton runat="server" ID="rbAgoAntecedenteCirugiaGUNo" GroupName="rbAgoAntecedenteCirugiaGU"
                    CssClass="rbAgoAntecedenteCirugiaGUNo" />
                <asp:RadioButton runat="server" ID="rbAgoAntecedenteCirugiaGUSi" GroupName="rbAgoAntecedenteCirugiaGU"
                    CssClass="rbAgoAntecedenteCirugiaGUSi" />
                <asp:RadioButton runat="server" ID="rbAgoAntecedenteAPPrematuraNo" GroupName="rbAgoAntecedenteAPPrematura"
                    CssClass="rbAgoAntecedenteAPPrematuraNo" />
                <asp:RadioButton runat="server" ID="rbAgoAntecedenteAPPrematuraSi" GroupName="rbAgoAntecedenteAPPrematura"
                    CssClass="rbAgoAntecedenteAPPrematuraSi" />
                <asp:RadioButton runat="server" ID="rbAgoAntecedenteRCIUNo" GroupName="rbAgoAntecedenteRCIU"
                    CssClass="rbAgoAntecedenteRCIUNo" />
                <asp:RadioButton runat="server" ID="rbAgoAntecedenteRCIUSi" GroupName="rbAgoAntecedenteRCIU"
                    CssClass="rbAgoAntecedenteRCIUSi" />
                <asp:RadioButton runat="server" ID="rbAgoAntecedenteHemorragiaObstetricaNo" GroupName="rbAgoAntecedenteHemorragiaObstetrica"
                    CssClass="rbAgoAntecedenteHemorragiaObstetricaNo" />
                <asp:RadioButton runat="server" ID="rbAgoAntecedenteHemorragiaObstetricaSi" GroupName="rbAgoAntecedenteHemorragiaObstetrica"
                    CssClass="rbAgoAntecedenteHemorragiaObstetricaSi" />
                <asp:RadioButton runat="server" ID="rbAgoAntecedenteMacrosomoiaFetalNo" GroupName="rbAgoAntecedenteMacrosomoiaFetal"
                    CssClass="rbAgoAntecedenteMacrosomoiaFetalNo" />
                <asp:RadioButton runat="server" ID="rbAgoAntecedenteMacrosomoiaFetalSi" GroupName="rbAgoAntecedenteMacrosomoiaFetal"
                    CssClass="rbAgoAntecedenteMacrosomoiaFetalSi" />
                <asp:RadioButton runat="server" ID="rbAgoAntecedentePolihidramniosNo" GroupName="rbAgoAntecedentePolihidramnios"
                    CssClass="rbAgoAntecedentePolihidramniosNo" />
                <asp:RadioButton runat="server" ID="rbAgoAntecedentePolihidramniosSi" GroupName="rbAgoAntecedentePolihidramnios"
                    CssClass="rbAgoAntecedentePolihidramniosSi" />
                <asp:RadioButton runat="server" ID="rbAgoAntecedenteOligoanmiosNo" GroupName="rbAgoAntecedenteOligoanmios"
                    CssClass="rbAgoAntecedenteOligoanmiosNo" />
                <asp:RadioButton runat="server" ID="rbAgoAntecedenteOligoanmiosSi" GroupName="rbAgoAntecedenteOligoanmios"
                    CssClass="rbAgoAntecedenteOligoanmiosSi" />
                <asp:RadioButton runat="server" ID="rbAgoAntecedenteRPMembranasNo" GroupName="rbAgoAntecedenteRPMembranas"
                    CssClass="rbAgoAntecedenteRPMembranasNo" />
                <asp:RadioButton runat="server" ID="rbAgoAntecedenteRPMembranasSi" GroupName="rbAgoAntecedenteRPMembranas"
                    CssClass="rbAgoAntecedenteRPMembranasSi" />
                <asp:RadioButton runat="server" ID="rbAgoAntecedenteIsoInmunizacionesNo" GroupName="rbAgoAntecedenteIsoInmunizaciones"
                    CssClass="rbAgoAntecedenteIsoInmunizacionesNo" />
                <asp:RadioButton runat="server" ID="rbAgoAntecedenteIsoInmunizacionesSi" GroupName="rbAgoAntecedenteIsoInmunizaciones"
                    CssClass="rbAgoAntecedenteIsoInmunizacionesSi" />
                <asp:RadioButton runat="server" ID="rbAgoAntecedenteColestasisNo" GroupName="rbAgoAntecedenteColestasis"
                    CssClass="rbAgoAntecedenteColestasisNo" />
                <asp:RadioButton runat="server" ID="rbAgoAntecedenteColestasisSi" GroupName="rbAgoAntecedenteColestasis"
                    CssClass="rbAgoAntecedenteColestasisSi" />
                <asp:RadioButton runat="server" ID="rbAgoAntecedenteMortPerinRecurrenteNo" GroupName="rbAgoAntecedenteMortPerinRecurrente"
                    CssClass="rbAgoAntecedenteMortPerinRecurrenteNo" />
                <asp:RadioButton runat="server" ID="rbAgoAntecedenteMortPerinRecurrenteSi" GroupName="rbAgoAntecedenteMortPerinRecurrente"
                    CssClass="rbAgoAntecedenteMortPerinRecurrenteSi" />
                <asp:RadioButton runat="server" ID="rbAgoAntecedenteRetencionPlacentaNo" GroupName="rbAgoAntecedenteRetencionPlacenta"
                    CssClass="rbAgoAntecedenteRetencionPlacentaNo" />
                <asp:RadioButton runat="server" ID="rbAgoAntecedenteRetencionPlacentaSi" GroupName="rbAgoAntecedenteRetencionPlacenta"
                    CssClass="rbAgoAntecedenteRetencionPlacentaSi" />
                <asp:RadioButton runat="server" ID="rbAgoAntecedenteDistociaHombrosNo" GroupName="rbAgoAntecedenteDistociaHombros"
                    CssClass="rbAgoAntecedenteDistociaHombrosNo" />
                <asp:RadioButton runat="server" ID="rbAgoAntecedenteDistociaHombrosSi" GroupName="rbAgoAntecedenteDistociaHombros"
                    CssClass="rbAgoAntecedenteDistociaHombrosSi" />
                <asp:RadioButton runat="server" ID="rbAgoAntecedenteMalformCongenNo" GroupName="rbAgoAntecedenteMalformCongen"
                    CssClass="rbAgoAntecedenteMalformCongenNo" />
                <asp:RadioButton runat="server" ID="rbAgoAntecedenteMalformCongenSi" GroupName="rbAgoAntecedenteMalformCongen"
                    CssClass="rbAgoAntecedenteMalformCongenSi" />
                <!-- Antecedentes Gineco Obstetricos: Actual-->
                <asp:RadioButton runat="server" ID="rbAgoActualEclampsiaNo" GroupName="rbAgoActualEclampsia"
                    CssClass="rbAgoActualEclampsiaNo" alert-group="Eclampsia" />
                <asp:RadioButton runat="server" ID="rbAgoActualEclampsiaSi" GroupName="rbAgoActualEclampsia"
                    CssClass="rbAgoActualEclampsiaSi" alert-message="Alerta: Eclampsia" alert-group="Eclampsia" />
                <asp:RadioButton runat="server" ID="rbAgoActualPreeclampsiaNo" GroupName="rbAgoActualPreeclampsia"
                    CssClass="rbAgoActualPreeclampsiaNo" alert-group="Preeclampsia" />
                <asp:RadioButton runat="server" ID="rbAgoActualPreeclampsiaSi" GroupName="rbAgoActualPreeclampsia"
                    CssClass="rbAgoActualPreeclampsiaSi" alert-message="Alerta: Preeclampsia" alert-group="Preeclampsia" />
                <asp:RadioButton runat="server" ID="rbAgoActualCirugiaGUNo" GroupName="rbAgoActualCirugiaGU"
                    CssClass="rbAgoActualCirugiaGUNo" alert-group="CirugiaGU" />
                <asp:RadioButton runat="server" ID="rbAgoActualCirugiaGUSi" GroupName="rbAgoActualCirugiaGU"
                    CssClass="rbAgoActualCirugiaGUSi" alert-message="Alerta: Cirugia Genito Urinaria"
                    alert-group="CirugiaGU" />
                <asp:RadioButton runat="server" ID="rbAgoActualAPPrematuraNo" GroupName="rbAgoActualAPPrematura"
                    CssClass="rbAgoActualAPPrematuraNo" alert-group="APPrematura" />
                <asp:RadioButton runat="server" ID="rbAgoActualAPPrematuraSi" GroupName="rbAgoActualAPPrematura"
                    CssClass="rbAgoActualAPPrematuraSi" alert-message="Alerta: A.P.Premaura" alert-group="APPrematura" />
                <asp:RadioButton runat="server" ID="rbAgoActualRCIUNo" GroupName="rbAgoActualRCIU"
                    CssClass="rbAgoActualRCIUNo" alert-group="RCIU" />
                <asp:RadioButton runat="server" ID="rbAgoActualRCIUSi" GroupName="rbAgoActualRCIU"
                    CssClass="rbAgoActualRCIUSi" alert-message="Alerta: R.C.I.U." alert-group="RCIU" />
                <asp:RadioButton runat="server" ID="rbAgoActualHemorragiaObstetricaNo" GroupName="rbAgoActualHemorragiaObstetrica"
                    CssClass="rbAgoActualHemorragiaObstetricaNo" alert-group="HemorragiaObstetrica" />
                <asp:RadioButton runat="server" ID="rbAgoActualHemorragiaObstetricaSi" GroupName="rbAgoActualHemorragiaObstetrica"
                    CssClass="rbAgoActualHemorragiaObstetricaSi" alert-message="Alerta: Hemorragia Obstetrica"
                    alert-group="HemorragiaObstetrica" />
                <asp:RadioButton runat="server" ID="rbAgoActualMacrosomoiaFetalNo" GroupName="rbAgoActualMacrosomoiaFetal"
                    CssClass="rbAgoActualMacrosomoiaFetalNo" alert-group="MacrosomoiaFetal" />
                <asp:RadioButton runat="server" ID="rbAgoActualMacrosomoiaFetalSi" GroupName="rbAgoActualMacrosomoiaFetal"
                    CssClass="rbAgoActualMacrosomoiaFetalSi" alert-message="Alerta: Macrosomia Fetal"
                    alert-group="MacrosomoiaFetal" />
                <asp:RadioButton runat="server" ID="rbAgoActualPolihidramniosNo" GroupName="rbAgoActualPolihidramnios"
                    CssClass="rbAgoActualPolihidramniosNo" alert-group="Polihidramnios" />
                <asp:RadioButton runat="server" ID="rbAgoActualPolihidramniosSi" GroupName="rbAgoActualPolihidramnios"
                    CssClass="rbAgoActualPolihidramniosSi" alert-message="Alerta: Polihidramnios"
                    alert-group="Polihidramnios" />
                <asp:RadioButton runat="server" ID="rbAgoActualOligoanmiosNo" GroupName="rbAgoActualOligoanmios"
                    CssClass="rbAgoActualOligoanmiosNo" alert-group="Oligoanmios" />
                <asp:RadioButton runat="server" ID="rbAgoActualOligoanmiosSi" GroupName="rbAgoActualOligoanmios"
                    CssClass="rbAgoActualOligoanmiosSi" alert-message="Alerta: Oligoanmios" alert-group="Oligoanmios" />
                <asp:RadioButton runat="server" ID="rbAgoActualRPMembranasNo" GroupName="rbAgoActualRPMembranas"
                    CssClass="rbAgoActualRPMembranasNo" alert-group="RPMembranas" />
                <asp:RadioButton runat="server" ID="rbAgoActualRPMembranasSi" GroupName="rbAgoActualRPMembranas"
                    CssClass="rbAgoActualRPMembranasSi" alert-message="Alerta: Rotura Prematura de Membranas"
                    alert-group="RPMembranas" />
                <asp:RadioButton runat="server" ID="rbAgoActualIsoInmunizacionesNo" GroupName="rbAgoActualIsoInmunizaciones"
                    CssClass="rbAgoActualIsoInmunizacionesNo" alert-group="IsoInmunizaciones" />
                <asp:RadioButton runat="server" ID="rbAgoActualIsoInmunizacionesSi" GroupName="rbAgoActualIsoInmunizaciones"
                    CssClass="rbAgoActualIsoInmunizacionesSi" alert-message="Alerta: IsoInmunizaciones"
                    alert-group="IsoInmunizaciones" />
                <asp:RadioButton runat="server" ID="rbAgoActualColestasisNo" GroupName="rbAgoActualColestasis"
                    CssClass="rbAgoActualColestasisNo" alert-group="Colestasis" />
                <asp:RadioButton runat="server" ID="rbAgoActualColestasisSi" GroupName="rbAgoActualColestasis"
                    CssClass="rbAgoActualColestasisSi" alert-message="Alerta: Colestasis" alert-group="Colestasis" />
                <!-- Factores de Riesgo -->
                <asp:RadioButton runat="server" ID="rbFactorRiesgoEmbarazoSinContSocialSi" GroupName="EmbarazoSinContSocial"
                    CssClass="rbFactorRiesgoEmbarazoSinContSocialSi" alert-message="Embarazo sin Contencion social<br>Se recomienda Intervención"
                    alert-group="EmbarazoSinContSocial" />
                <asp:RadioButton runat="server" ID="rbFactorRiesgoEmbarazoSinContSocialNo" GroupName="EmbarazoSinContSocial"
                    CssClass="rbFactorRiesgoEmbarazoSinContSocialNo" alert-group="EmbarazoSinContSocial" />
                <asp:RadioButton runat="server" ID="rbFactorRiesgoFamiliaSinIngresosFijosSi" GroupName="FamiliaSinIngresosFijos"
                    CssClass="rbFactorRiesgoFamiliaSinIngresosFijosSi" alert-message="Familia sin Ingresos Fijos<br>Se recomienda Intervención"
                    alert-group="FamiliaSinIngresosFijos" />
                <asp:RadioButton runat="server" ID="rbFactorRiesgoFamiliaSinIngresosFijosNo" GroupName="FamiliaSinIngresosFijos"
                    CssClass="rbFactorRiesgoFamiliaSinIngresosFijosNo" alert-group="FamiliaSinIngresosFijos" />
                <asp:RadioButton runat="server" ID="rbFactorRiesgoEmbarazoFuertRechazadoSi" GroupName="EmbarazoFuertRechazado"
                    CssClass="rbFactorRiesgoEmbarazoFuertRechazadoSi" alert-message="Embarazo fuertemente Rechazado<br>Se recomienda Intervención"
                    alert-group="EmbarazoFuertRechazado" />
                <asp:RadioButton runat="server" ID="rbFactorRiesgoEmbarazoFuertRechazadoNo" GroupName="EmbarazoFuertRechazado"
                    CssClass="rbFactorRiesgoEmbarazoFuertRechazadoNo" alert-group="EmbarazoFuertRechazado" />
                <asp:RadioButton runat="server" ID="rbFactorRiesgoHijosDadosAdopcionSi" GroupName="HijosDadosAdopcion"
                    CssClass="rbFactorRiesgoHijosDadosAdopcionSi" alert-message="Hijos dados en adopcion<br>Se recomienda Intervención"
                    alert-group="HijosDadosAdopcion" />
                <asp:RadioButton runat="server" ID="rbFactorRiesgoHijosDadosAdopcionNo" GroupName="HijosDadosAdopcion"
                    CssClass="rbFactorRiesgoHijosDadosAdopcionNo" alert-group="HijosDadosAdopcion" />
                <asp:RadioButton runat="server" ID="rbFactorRiesgoViviendaSinServiciosBasicosSi"
                    GroupName="ViviendaSinServiciosBasicos" CssClass="rbFactorRiesgoViviendaSinServiciosBasicosSi"
                    alert-message="Vivienda sin Servicios Basicos<br>Se recomienda Intervención"
                    alert-group="ViviendaSinServiciosBasicos" />
                <asp:RadioButton runat="server" ID="rbFactorRiesgoViviendaSinServiciosBasicosNo"
                    GroupName="ViviendaSinServiciosBasicos" CssClass="rbFactorRiesgoViviendaSinServiciosBasicosNo"
                    alert-group="ViviendaSinServiciosBasicos" />
                <!-- Captacion Oportuna -->
                <asp:RadioButton runat="server" ID="rbCaptacionOportunaDespues16Sem" GroupName="CaptacionOportuna"
                    CssClass="rbCaptacionOportunaDespues16Sem" />
                <asp:RadioButton runat="server" ID="rbCaptacionOportunaAntes16Sem" GroupName="CaptacionOportuna"
                    CssClass="rbCaptacionOportunaAntes16Sem" />
                <!--Muestra PAP -->
                <asp:TextBox runat="server" ID="txtFechaMuestraPAP" CssClass="txtFechaMuestraPAP textBoxSmallchars datepicker22"></asp:TextBox>
                <!-- Colocacion Tripla Acelular -->
                <asp:TextBox runat="server" ID="txtFechaTripleAcelular" CssClass="txtFechaTripleAcelular textBoxSmallchars datepicker22"
                    ToolTip="Indicar Vacuna Acelular >20 Sem. (Única vez)" ValidationGroup="" alert-message="Se recomienda Vacuna Triple Acelular, por única vez"></asp:TextBox>
                <!-- Colocacion N1H1 -->
                <asp:TextBox runat="server" ID="txtFechaAntigripal" CssClass="txtFechaAntigripal textBoxSmallchars datepicker22"
                    ToolTip="Se recomienda indicar Vacuna Antigripal" ValidationGroup="" alert-message="Se recomienda Vacuna Antigripal"></asp:TextBox>
                <!-- Desarrolla enfermedad en el embarazo actual -->
                <asp:RadioButton runat="server" ID="rbDesarrollaAnemiaNo" GroupName="DesarrollaAnemiaNo"
                    CssClass="rbDesarrollaAnemiaNo" />
                <asp:RadioButton runat="server" ID="rbDesarrollaAnemiaSi" GroupName="DesarrollaAnemiaSi"
                    CssClass="rbDesarrollaAnemiaSi" />
                <asp:RadioButton runat="server" ID="rbDesarrollaDiabetesNo" GroupName="DesarrollaDiabetesNo"
                    CssClass="rbDesarrollaDiabetesNo" />
                <asp:RadioButton runat="server" ID="rbDesarrollaDiabetesSi" GroupName="DesarrollaDiabetesSi"
                    CssClass="rbDesarrollaDiabetesSi" />
                <!--esto para que sea un campo requerido
            CssClass="txtFechaAntigripal textBoxSmallchars validate[required]" -->
            </div>
            <!-- detalles de consultas de SIP -->
            <div id="sipDetallesContainer">
                <asp:Repeater runat="server" ID="rptDetalles">
                    <ItemTemplate>
                        <div class="sipDetalles">
                            <asp:Label runat="server" ID="lblDetalleFecha" Text='<%# Eval("Fecha","{0:dd/MM/yyyy}") %>'
                                CssClass="lblDetalleFecha lblDetalle"></asp:Label>
                            <asp:Label runat="server" ID="lblDetalleEdadGestacional" Text='<%# Eval("EdadGestacional","{0:0.0}") %>'
                                CssClass="lblDetalleEdadGestacional lblDetalle"></asp:Label>
                            <asp:Label runat="server" ID="lblDetallePeso" Text='<%# Eval("Peso") %>' CssClass="lblDetallePeso lblDetalle"></asp:Label>
                            <asp:Label runat="server" ID="lblDetallePresionArterial" Text='<%# Eval("Pa") %>'
                                CssClass="lblDetallePresionArterial lblDetalle"></asp:Label>
                            <asp:Label runat="server" ID="lblDetalleAlturaUterina" Text='<%# Eval("AlturaUterina") %>'
                                CssClass="lblDetalleAlturaUterina lblDetalle"></asp:Label>
                            <asp:Label runat="server" ID="lblDetallePresentacion" Text='<%# Eval("Presentacion") %>'
                                CssClass="lblDetallePresentacion lblDetalle"></asp:Label>
                            <asp:Label runat="server" ID="lblDetalleFrecuenciaCardiacaFetal" Text='<%# Eval("Fcf") %>'
                                CssClass="lblDetalleFrecuenciaCardiacaFetal lblDetalle"></asp:Label>
                            <asp:Label runat="server" ID="lblDetalleMovimientosFetales" Text='<%# Eval("MovimientosFetales") %>'
                                CssClass="lblDetalleMovimientosFetales lblDetalle"></asp:Label>
                            <asp:Label runat="server" ID="lblDetalleProteinuria" Text='<%# Eval("Proteinuria") %>'
                                CssClass="lblDetalleProteinuria lblDetalle"></asp:Label>
                            <asp:Label runat="server" ID="lblDetalleAlarmaExamenesTratamientos" Text='<%# Eval("AlarmaExamenesTratamientos") %>'
                                CssClass="lblDetalleAlarmaExamenesTratamientos lblDetalle" Title='<%# Eval("AlarmaExamenesTratamientos") %>'></asp:Label>
                            <asp:Label runat="server" ID="lblDetallesInicialesTecnico" Text='<%# Eval("InicialesTecnico") %>'
                                CssClass="lblDetalleInicialesTecnico lblDetalle"></asp:Label>
                            <asp:Label runat="server" ID="lblDetalleProximaCita" Text='<%# Eval("ProximaCita","{0:dd/MM/yyyy}") %>'
                                CssClass="lblDetalleProximaCita lblDetalle"></asp:Label>
                            <asp:Label runat="server" ID="lblDetalleIMC" Text='<%# Eval("IMC") %>' CssClass="lblDetalleIMC lblDetalle"></asp:Label>
                            <asp:Label runat="server" ID="lblDetalleObservaciones" Text='<%# Eval("Observaciones") %>'
                                CssClass="lblDetalleObservaciones lblDetalle" Title='<%# Eval("Observaciones") %>'></asp:Label>
                            
                            
                            
                         <%--   <asp:HyperLink ID="hlEditar" CssClass="hlEditar" ImageUrl="~/ConsultaAmbulatoria/ControlPerinatal/css/editar.png"
                                ToolTip="Click para editar el Control." Target="_blank" runat="server" NavigateUrl='<%# "EditarControl.aspx?id=" + Eval("idHistoriaClinicaPerinatalDetalle").ToString() %>'></asp:HyperLink>
                       
                            --%>

                               <asp:HyperLink runat="server" ID="detallehcp" text="editar123" OnClick="detallehcp_Click" ImageUrl="~/ConsultaAmbulatoria/ControlPerinatal/css/editar.png"  CssClass="hlEditar" NavigateUrl='<%# "/SIPS/ConsultaAmbulatoria/ControlPerinatal/Control/?idHistoriaClinicaPerinatal=" + Eval("idHistoriaClinicaPerinatal").ToString() + "&idHistoriaClinicaPerinatalDetalle=" + Eval("idHistoriaClinicaPerinatalDetalle").ToString()%>'></asp:HyperLink>
                         
                            
                             </div>
                    </ItemTemplate>
                </asp:Repeater>
                <!--Ingreso de nuevo Detalle-->
                <div class="sipDetalles">
                    <asp:TextBox runat="server" ID="txtDetalleFecha" CssClass="txtDetalleFecha txtDetalle datepicker22" ></asp:TextBox>
                    <asp:TextBox runat="server" ID="txtDetalleEdadGestacional" CssClass="txtDetalleEdadGestacional txtDetalle"></asp:TextBox>
                    <asp:TextBox runat="server" ID="txtDetallePeso" CssClass="validate[custom[number],min[40],max[200]] txtDetallePeso txtDetalle"></asp:TextBox>
                    <asp:TextBox runat="server" ID="txtDetallePresionArterialSistolica" CssClass="validate[custom[number],min[0],max[200]] txtDetallePresionArterialSistolica txtDetalle"></asp:TextBox>
                    <asp:TextBox runat="server" ID="txtDetallePresionArterialDistolica" CssClass="validate[custom[number],min[0],max[130]] txtDetallePresionArterialDistolica txtDetalle"></asp:TextBox>
                    <asp:TextBox runat="server" ID="txtDetalleAlturaUterina" CssClass="validate[custom[number],min[0],max[44]] txtDetalleAlturaUterina txtDetalle"></asp:TextBox>
                    <asp:TextBox runat="server" ID="txtDetallePresentacion" CssClass="txtDetallePresentacion txtDetalle"></asp:TextBox>
                    <asp:TextBox runat="server" ID="txtDetalleFrecuenciaCardiacaFetal" CssClass="validate[custom[number],min[0],max[200]] txtDetalleFrecuenciaCardiacaFetal txtDetalle"></asp:TextBox>
                    <asp:TextBox runat="server" ID="txtDetalleMovimientosFetales" CssClass="txtDetalleMovimientosFetales txtDetalle"></asp:TextBox>
                    <asp:TextBox runat="server" ID="txtDetalleProteinuria" CssClass="txtDetalleProteinuria txtDetalle"></asp:TextBox>
                    <asp:TextBox runat="server" ID="txtDetalleAlarmaExamenesTratamientos" CssClass="txtDetalleAlarmaExamenesTratamientos txtDetalle"></asp:TextBox>
                    <asp:TextBox runat="server" ID="txtDetallesInicialesTecnico" CssClass="txtDetalleInicialesTecnico txtDetalle"></asp:TextBox>
                    <asp:TextBox runat="server" ID="txtDetalleProximaCita" CssClass="txtDetalleProximaCita txtDetalle datepicker22"></asp:TextBox>
                    <asp:TextBox runat="server" ID="txtDetalleIMC" CssClass="txtDetalleIMC txtDetalle"></asp:TextBox>
                    <asp:TextBox runat="server" ID="txtDetalleObservaciones" CssClass="txtDetalleObservaciones txtDetalle"></asp:TextBox>
                </div>
            </div>
            <br />
           
      
            <table class="formulario">
                <tr>
                    <td>Seleccione Efector de Traslado Intrauterino:
                    <asp:DropDownList ID="ddlEfectorTraslado" runat="server" DataTextField="Nombre" DataValueField="idEfector" AutoPostBack="true" OnSelectedIndexChanged="ddlEfectorTraslado_SelectedIndexChanged" ToolTip="Seleccione si hubo traslado Intrauterino" CssClass="form-control"/>
                        <asp:HiddenField ID="hfIdEfectorTraslado" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    </div>


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="server">




     <!-- Modal -->
    <div class="modal fade" id="myModal" role="dialog">
        <div class="modal-dialog modalperson">


            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">
                        <p style="color: #000"><b>Editar control </b></p>
                    </h4>
                </div>
                <div class="modal-body">


                    <div class="panel panel-default">
                       

                        <asp:HiddenField runat="server" ID="HiddenField1" />
    <div id="sipDetallesContainer">
       <div class="sipDetalles">
                <asp:TextBox runat="server" ID="txtDetalleFecha2" CssClass="txtDetalleFecha txtDetalle datepicker22"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtDetalleEdadGestacional2" CssClass="txtDetalleEdadGestacional txtDetalle"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtDetallePeso2" CssClass="validate[custom[number],min[40],max[200]] txtDetallePeso txtDetalle" ToolTip="Ingrese un valor con Coma decimal"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtDetallePresionArterialSistolica2" CssClass="validate[custom[number],min[0],max[200]] txtDetallePresionArterialSistolica txtDetalle"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtDetallePresionArterialDistolica2" CssClass="validate[custom[number],min[0],max[130]] txtDetallePresionArterialDistolica txtDetalle"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtDetalleAlturaUterina2" CssClass="txtDetalleAlturaUterina txtDetalle"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtDetallePresentacion2" CssClass="txtDetallePresentacion txtDetalle"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtDetalleFrecuenciaCardiacaFetal2" CssClass="txtDetalleFrecuenciaCardiacaFetal txtDetalle"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtDetalleMovimientosFetales2" CssClass="txtDetalleMovimientosFetales txtDetalle"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtDetalleProteinuria2" CssClass="txtDetalleProteinuria txtDetalle"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtDetalleAlarmaExamenesTratamientos2" CssClass="txtDetalleAlarmaExamenesTratamientos txtDetalle"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtDetallesInicialesTecnico2" CssClass="txtDetalleInicialesTecnico txtDetalle"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtDetalleProximaCita2" CssClass="txtDetalleProximaCita txtDetalle datepicker22"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtDetalleIMC2" CssClass="txtDetalleIMC txtDetalle" ToolTip="Ingrese un valor con Coma decimal"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtDetalleObservaciones2" CssClass="txtDetalleObservaciones txtDetalle"></asp:TextBox>
            </div>
      
        </div>


                    </div>



                </div>
                <div class="modal-footer">
                  <%--  <asp:Button runat="server" ID="btnEliminar" Text="Eliminar el Control" OnClick="btnEliminar_Click"
        ToolTip="Eliminar el control actual"  CssClass="btn btn-md"/>
    &nbsp;&nbsp;&nbsp;--%>
    <asp:Button runat="server" ID="Button1" Text="Guardar" OnClick="btnGuardar2_Click"
        ToolTip="Guardar Control." CssClass="btn btn-md botonColor"/>
    &nbsp;&nbsp;&nbsp;
   <asp:Button runat="server" ID="btnEliminar" Text="Eliminar el Control" OnClick="btnEliminar_Click"
        ToolTip="Eliminar el control actual"  CssClass="btn btn-md botonColor"/>
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
                </div>
            </div>

        </div>

    </div>

    <!-- Fin Modal -->






    <asp:Button runat="server" ID="btnGuardar" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-warning btn-md botonColor"
        Enabled="true" ToolTip="Guardar los cambios realizados." />
    <a class="btn btn-warning btn-md botonColor" onclick="imprimir()" style="text-decoration:none;">Imprimir</a>
    <%--<asp:Button ID="btnPrint" runat="server" Text="Imprimir" OnClientClick="imprimir()" CssClass="btn btn-warning btn-md botonColor" ToolTip="Imprime el control perinatal." />--%>
    <asp:Button runat="server" Text="Volver" ID="btnVolver" OnClick="btnVolver_Click" CssClass="btn btn-warning btn-md botonColor" ToolTip="Volver a pagina principal." formnovalidate/>

    <%--<asp:Button runat="server" ID="btnNuevo" Text="NuevoControl" OnClick="btnNuevo_Click"
        ToolTip="Nuevo Control" />--%>
    <%--  &nbsp;&nbsp;&nbsp;
    <input type="button" value="Actualizar Control" title="Refresca la página y relee los datos editados del control"
        onclick="document.location.reload();" />--%>
    <script>
       // txtDetalleProximaCita
        $('#<%= txtDetalleProximaCita.ClientID %>').click(function () {


            if ($('#<%= txtDetalleFecha.ClientID %>').val() == "") {

                $('#<%= txtDetalleFecha.ClientID %>').css("border-color", "red");
                $('#<%= txtDetalleFecha.ClientID %>').focus()
            }

            

        });

        $('#<%= txtDetalleFecha.ClientID %>').hover(function () {

            //if ($('#<%= txtDetalleFecha.ClientID %>').val() != "") {
            $('#<%= txtDetalleFecha.ClientID %>').css("border-color", "white");

            //}

        });
     function alertaDeQueSeGuardo() {
     
       addAlertOK('Los cambios se guardaron correctamente');


     }
     function alertaDeQueSeBorro() {

         addAlertOFF('Se Elimino el detalle de la historia clinica perinatal');


     }

         function ModalDetalles() {
             $("#myModal").modal("show");
         }

        //Pongo decimales al peso.
         <%--$('#<%= txtDetallePeso2.ClientID %>').blur(function () {
             x = parseInt($('#<%= txtDetallePeso2.ClientID %>').val());
             pesoTemp = x.toFixed(3);
             $('#<%= txtDetallePeso2.ClientID %>').val(pesoTemp);
             
         });--%>

    </script>

</asp:Content>
