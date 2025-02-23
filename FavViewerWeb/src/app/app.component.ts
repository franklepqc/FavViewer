import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ILien } from './ILien';
import { LiensService } from './liens.service';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  // Liste des liens.
  liens: ILien[] = [];

  /**
   * Constructeur.
   * @param serviceLiens Injection du service pour les liens.
   */
  constructor (private serviceLiens: LiensService, private domSanitizer: DomSanitizer) { }

  /**
   * Ouvre un nouvel onglet pour ouvrir le lien.
   * @param id Identifiant.
   */
  ouvrirLecture(id: number) {
    
  }

  /**
   * Supprimer le lien.
   * @param id Identifiant.
   */
  supprimer(id: number) {
    
  }
}
