
# Enregistrement et chargement de chemins

L'application étant partagée en deux parties, l'éditeur et le lecteur, il a fallu définir un format de fichier permettant d'exporter des dessins depuis l'éditeur et de le importer dans le lecteur. Ce format est basé sur _XML_[^XML] et est inspiré du format _SVG_[^SVG]. Il n'est cependant pas intercompatible avec ce dernier. Ce format a été baptisé _MouvML_, pour _Mouvtor Markup Language_.

Les sections suivantes décrivent les différentes balises présentes dans un fichier _MouvML_.

[^XML]:  _Extensible Markup Language_, un format standard de fichier permettant de stocker des informations de manière hiérarchique. 

[^SVG]: _Simple Vector Graphics_, un format standard permettant de décrire des images vectorielles.

## Balises d'un fichier _MouvML_ 

_MouvML_ étant basé sur _XML_ Un fichier _MouvML_ contient 3 sortes de balises, décrites dans les sections ci-dessous.

### Doctype

Comme tout fichier _XML_, la première ligne du fichier contient un _doctype_. Cette balise informe sur la version du standard _XML_ utilisé et l'encodage utilisé. _MouvML_ est basé sur la version 1.0 du standard _XML_. L'encodage utilisé pour les fichiers est _UTF-8_. 

Le _doctype_ d'un fichier _MouvML_ doit donc être identique à la ligne suivante:

```xml
<?xml version="1.0" encoding="utf-8"?>
```

### La balise `mouvml` 

Cette balise est la balise parente, qui englobe toutes les autres balises du fichier.  Elle doit __impérativement__ être définie au début du fichier, juste après le _doctype_.  Les enfants de cette balise sont des balises `path`.

Voici un exemple de balise `mouvml`:

```xml
<mouvml version="0.1">
    <!-- Les différents chemins du dessin sont définis ici -->
</mouvml>
```

Cette balise possède les propriétés suivantes:

| Nom | Obligatoire | Description | Exemple |
|-----|-------------|-------------|---------|
| `version` | oui | La version du format MouvML. La version actuelle est la version 1.0. Si le format MouvML est modifié ultérieurement (par exemple, en ajoutant une nouvelle balise), ce numéro de version devra être incrémenté. Cela permettra à l'application d'être consciente de la version du fichier et d'être capable de gérer différentes versions du format MouvML. | `version="1.0"` |
|-----|-------------|-------------|---------|

### Les balises `path`

Les balises `path` décrivent un chemin, c'est à dire une ligne tracée par l'utilisateur. Ces balises doivent être des enfants directs de la balise `mouvml`.  Cette balise contient différentes balises `point` qui décrivent chaque point du chemin. Les balises `point` sont décrites dans la section suivante.

Voici un exemple de balise `path` :

```xml
<path timestamp="3537">
    <!-- Les différents points du chemin sont définis ici -->
</path>
```

Les balises `path` possèdent les propriétés suivantes:

| Nom | Obligatoire | Description | Exemple |
|-----|-------------|-------------|---------|
| `timestamp` | Oui | Temps à partir duquel le dessin de ce chemin doit être commencé, en millisecondes depuis le début du dessin. | `timestamp="1337"`
|-----|-------------|-------------|---------|

### Les balises  `point`

Les balises `point` décrivent un point à l'intérieur d'un chemin, défini par les coordonnées et la pression du point ainsi que le moment auquel ce point doit être dessiné. . Ces balises doivent être des enfants directs d'une balise `path`. Les coordonnées définies dans une balise `point` sont _relatives_ et non _absolues_, ce qui permet de rendre un chemin indépendant de la taille de la zone de dessin et du périphérique de dessin utilisé.

Voici un exemple de balise `point` :

```xml
<point x="0.1337" y="0.42" z="0.9" timestamp="0" />
```

Les balises `point` possèdent les propriétés suivantes:

| Nom | Obligatoire | Description | Exemple |
|-----|-------------|-------------|---------|
| `x` | Oui | Position horizontale du point, comprise entre 0 (extrême gauche) et 1.0 (extrême droite).  | `x="0.002322"`
| `y` | Oui | Position verticale du point, comprise entre 0 (haut de l'image) et 1.0 (bas de l'image)| `y="0.239833"`|
| `z` | Oui | Profondeur du point, comprise entre 0 (profondeur minimale) et 1.0 (très profondeur maximale). La profondeur est représentée par l'épaisseur du trait dans l'application. | `z="0.999923"` |
| `timestamp` | Oui | Temps auquel ce point doit être dessiné, en millisecondes à partir du début du chemin parent. Ce temps est donc relatif au temps du chemin parent. | `timestamp="123"` |
|-----|-------------|-------------|---------|

## Écriture d'un fichier MouvML

L'écriture d'un fichier _MouvML_ se fait à l'aide de la classe `MouvmlWriter` qui est définie dans le projet _MouvtorCommon_. Cette classe permet de sauvegarder des chemins dans un fichier _MouvML_. 

Un chemin est défini dans l'application comme un objet de type `Path`. Il sera traduit en une balise `path` pendant l'export en fichier _MouvML_. Ce dernier est une liste spécialisée d'objets `PathStep`.

Un objet `PathStep` représente un point d'un chemin. Il sera traduit en une balise `point` pendant l'export en fichier _MouvML_.

Voici un exemple d'utilisation de la classe MouvmlWriter:

```csharp

// un chemin que l'on souhaite sauvegarder
var unChemin = new Path(timestamp: 123) 

// une collection de chemins que l'on souhaite aussi sauvegarder
var desChemins = new List<>

```


