import { HttpErrorResponse } from '@angular/common/http';
import { throwError } from 'rxjs';

type WebServiceError = {
    erro: any,
    mensagem: string,
    mensagemOriginal: string,
};

export function tratadorErro(erro: HttpErrorResponse) {
    let msg = '';
    if (erro.error instanceof ProgressEvent) {
        msg = `Erro: ${erro.error.type}`;
    } else {
        msg = `Status: ${erro.status} ${erro.statusText}`;
    }
    console.error(msg);
    return throwError(() => {
        let erroTratado: WebServiceError = {
            erro: erro.error,
            mensagem: msg,
            mensagemOriginal: erro.message
        };
        return erroTratado;
    });
}