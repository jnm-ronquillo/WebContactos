import {Component, Inject, OnInit} from '@angular/core';
import {Contacto} from '../contacto';
import {HttpClient} from '@angular/common/http';

@Component({
  selector: 'app-contacto',
  templateUrl: './contacto.component.html',
  styleUrls: ['./contacto.component.css']
})
export class ContactoComponent implements OnInit {
  contactos: Contacto[];
  collectionSize = 0;
  page = 1;
  pageSize = 2;

  contacto: Contacto = {
    contactoId: '',
    celular: '',
    correo: '',
    direccion: '',
    distrito: '',
    fechaNacimiento: '',
    id: null,
    nombres: '',
    numeroDocumento: '',
    primerApellido: '',
    segundoApellido: '',
    tipoDocumento: ''
  };

  http: HttpClient;
  baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
    http.get<Contacto[]>(baseUrl + 'api/contacto/GetAll').subscribe(result => {
      this.contactos = result;
      this.collectionSize = this.contactos.length;
    }, error => console.error(error));
  }

  ngOnInit() {
  }

  refreshContactos() {
    this.http.get<Contacto[]>(this.baseUrl + 'api/contacto/GetAll').subscribe(result => {
      this.contactos = result;
      this.collectionSize = this.contactos.length;
    }, error => console.error(error));
  }

  nuevoContacto() {
    this.contacto = {
      contactoId: '',
      celular: '',
      correo: '',
      direccion: '',
      distrito: '',
      fechaNacimiento: '',
      id: null,
      nombres: '',
      numeroDocumento: '',
      primerApellido: '',
      segundoApellido: '',
      tipoDocumento: ''
    };
  }

  guardarContacto() {
    console.log(this.contacto);

    this.http.post(this.baseUrl + 'api/contacto', this.contacto).subscribe(result => {
      this.nuevoContacto();
      this.refreshContactos();
    }, error => console.error(error));
  }

  eliminarItem(contacto: Contacto) {
    if (confirm('¿Esta Seguro?')) {
      this.http.delete(this.baseUrl + `api/contacto/${contacto.id}`, ).subscribe(result => {
        this.refreshContactos();
      }, error => console.error(error));
    }
  }

  editarItem(contacto: Contacto) {
    this.contacto = {...contacto};
  }
}
