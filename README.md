# Máquina de Café — Práctica TDD

## ¿Qué es TDD?
Test-Driven Development (TDD) es una metodología donde el programador escribe
la prueba antes de escribir el código. El proceso se repite en ciclos cortos
hasta que toda la funcionalidad esté implementada.

## Ciclo Red → Green → Refactor
- **RED**: Se escribe una prueba que falla porque el código no existe aún.
- **GREEN**: Se escribe el código mínimo para que la prueba pase.
- **REFACTOR**: Se mejora el diseño sin romper las pruebas.

## Estructura del proyecto
MaquinaCafeTDD/

├── MaquinaCafe/          # Proyecto principal

│   └── MaquinaCafe.cs    # Clase con la lógica de la máquina

├── MaquinaCafe.Tests/    # Proyecto de pruebas

│   └── UnitTest1.cs      # 8 casos de prueba (TC-01 al TC-08)

└── README.md
## Casos de prueba
| Test | Descripción |
|------|-------------|
| TC-01 | Insertar moneda acumula el saldo |
| TC-02 | Saldo suficiente retorna true |
| TC-03 | Saldo insuficiente retorna false |
| TC-04 | Devuelve el cambio correcto |
| TC-05 | Bebida inexistente lanza ArgumentException |
| TC-06 | El menú contiene 3 bebidas con precios correctos |
| TC-07 | Devolver monedas reinicia el saldo a cero |
| TC-08 | Stock agotado impide dispensar la bebida |

## Cómo ejecutar el proyecto
1. Abrir `MaquinaCafeTDD.sln` en Visual Studio 
2. Ir a **Prueba → Ejecutar todas las pruebas**
3. Verificar que los 8 tests aparecen en verde en el Explorador de pruebas