using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    public class Game : GameWindow
    {
       
        
        public Cubo cubo, cubo2, cubo3, cubo4, cubo5, cubo6, cubo7, cubo8, cubo9;
        //-----------------------------------------------------------------------------------------------------------------
        public Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title) { }
        //-----------------------------------------------------------------------------------------------------------------
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }
        //-----------------------------------------------------------------------------------------------------------------
        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(Color4.SeaGreen);
            // Coordenada x,y,z
            // ancho, alto, profundidad, color
            //Pared
            cubo = new Cubo(new Punto(8,0,0), 1,  22, 30, Color.Brown);
            //Repisa
            cubo2 = new Cubo(new Punto(1,10,0), 5, 2, 15, Color.RosyBrown);
            //Chasis
            cubo3 = new Cubo(new Punto(3, 15, 0), 3, 2, 12, Color.Blue);
            //chasis arriba
            cubo4 = new Cubo(new Punto(1, 20, 0), 3, 3, 5, Color.Blue);
            // Ventana
            cubo5 = new Cubo(new Punto(2, 20, 0), 2, 2, 8, Color.White);
            //Llanta izquierda
            cubo6 = new Cubo(new Punto(0, 14, 6), 2, 2, 2, Color.Black);
            //Llanta derecha
            cubo7 = new Cubo(new Punto(0, 14, -6), 2, 2, 2, Color.Black);
            // Luz derecha
            cubo8 = new Cubo(new Punto(5, 15, 10), 1, 1, 4, Color.Yellow);
            // Luz izquierda
            cubo9 = new Cubo(new Punto(1, 15, 10), 1, 1, 4, Color.Yellow);

            base.OnLoad(e);     
        }
        //-----------------------------------------------------------------------------------------------------------------
        protected override void OnUnload(EventArgs e)
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            //GL.DeleteBuffer(VertexBufferObject);
            base.OnUnload(e);
        }
        //-----------------------------------------------------------------------------------------------------------------
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            //GL.DepthMask(true);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.DepthTest);
            GL.LoadIdentity();
            //---------------------
            // Configura la matriz de vista (View Matrix) para cambiar la vista
            Matrix4 viewMatrix = Matrix4.LookAt(new Vector3(-5, 5, 20), Vector3.Zero, Vector3.UnitY);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref viewMatrix);
            /////////////////////////////////////////////////

            //-----------------------
            //pared
            this.cubo.Dibujar();
            //Repisa
            this.cubo2.Dibujar();
            //Parte de abajo del chasis
            this.cubo3.Dibujar();
            //Parte de arriba del chasis
            this.cubo4.Dibujar();
            //Ventana
            this.cubo5.Dibujar();
            //Llanta izquierda
            this.cubo6.Dibujar();
            //Llanta derecha
            this.cubo7.Dibujar();
            //Luz izquierda
            this.cubo8.Dibujar();
            //Luz derecha
            this.cubo9.Dibujar();
            //DrawCircle(-4,14,-2,3,100);
            //DrawCircle(-4, 14, 6, 3, 100);
            //this.cubo4.Dibujar();
            //-----------------------
            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }
        //-----------------------------------------------------------------------------------------------------------------
        protected override void OnResize(EventArgs e)
        {
            float d = 30;
            GL.Viewport(0, 0, Width, Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-d, d, -d, d, -d, d);
            //GL.Frustum(-80, 80, -80, 80, 4, 100);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            base.OnResize(e);
        }
        private void DrawCircle(float x, float y, float z, float radius, int segments)
        {
            //GL.Rotate(-5, 1, 1, 0);
            GL.Color4(Color4.Pink);
            GL.Begin(PrimitiveType.TriangleFan);

            GL.Vertex3(x, y, z);

            for (int i = 0; i <= segments; i++)
            {
                float angle = 2.0f * MathHelper.Pi * i / segments;
                float xVertex = x + radius * (float)Math.Cos(angle);
                float yVertex = y + radius * (float)Math.Sin(angle);
                GL.Vertex3(xVertex, yVertex, z);
            }

            GL.End();
        }


    }
}
