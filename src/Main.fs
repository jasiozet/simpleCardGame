module Main

open Feliz
open App
open Browser.Dom
open Fable.Core.JsInterop

Fable.Core.JsInterop.importSideEffects "./index.css"

ReactDOM.render(
  Components.GameContainer(),
  document.getElementById "feliz-app"
)