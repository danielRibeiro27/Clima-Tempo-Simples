$(document).ready(function () {
    $('#select-cidades').select2();

    $('#select-cidades').on('select2:select', (e)=>{
      _cidadeId = e.params.data.id

      if(_cidadeId == "" || _cidadeId == null) {
        $("#info").html("");
        return;
      }

      $.ajax({
        type: 'POST', 
        url: "Home/GetPrevisao",
        data: { cidadeId: _cidadeId },
        dataType: "json",
        traditional: true,
        contenttype: "application/json; charset=utf-8",
        success: function (result) {
            let html = "";

            result.forEach(function (previsao){

                html += `<div class="main-box">

                    <div class="small-box">
                      <div class="previsao-clima-header">${previsao.DayOfWeek}</div>
                    </div>

                    <div>
                      <div class="previsao-clima-card" style="">Clima ${previsao.Clima} </div>
                      <div class="previsao-clima-card">Mínima ${previsao.TemperaturaMinima}°C </div>
                      <div class="previsao-clima-card">Máxima ${previsao.TemperaturaMaxima}°C </div>
                    </div>

                  </div>`

            });

            $("#info").html(html);
        },
        error:function(result){
            $("#info").html('<p style="color:red;">Erro na requisição.</p> <p style="color:red;">Checar se o URL atual está no formato: https://localhost:44365 sem nada mais á direita como "Home/Index".</p>')
        },
        complete: function (result) {
          
        }
    });

    })
});
