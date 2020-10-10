using Saxophon.Models;

namespace Saxophon.Services
{
    class NoteEnumerationService
    {
        public Note GetEnumNote(string param)
        {
            if (param.Equals("c1"))
            {
                return Note.c1;
            }
            if (param.Equals("cis1"))
            {
                return Note.cis1;
            }
            if (param.Equals("d1"))
            {
                return Note.d1;
            }
            if (param.Equals("dis1"))
            {
                return Note.dis1;
            }
            if (param.Equals("e1"))
            {
                return Note.e1;
            }
            if (param.Equals("es1"))
            {
                return Note.es1;
            }
            if (param.Equals("f1"))
            {
                return Note.f1;
            }
            if (param.Equals("fis1"))
            {
                return Note.fis1;
            }
            if (param.Equals("ges1"))
            {
                return Note.ges1;
            }
            if (param.Equals("g1"))
            {
                return Note.g1;
            }
            if (param.Equals("gis1"))
            {
                return Note.gis1;
            }
            if (param.Equals("as1"))
            {
                return Note.as1;
            }
            if (param.Equals("a1"))
            {
                return Note.a1;
            }
            if (param.Equals("ais1"))
            {
                return Note.ais1;
            }
            if (param.Equals("b1"))
            {
                return Note.b1;
            }
            if (param.Equals("h1"))
            {
                return Note.h1;
            }
            if (param.Equals("c2"))
            {
                return Note.c2;
            }
            if (param.Equals("cis2"))
            {
                return Note.cis2;
            }
            if (param.Equals("d2"))
            {
                return Note.d2;
            }
            if (param.Equals("dis2"))
            {
                return Note.dis2;
            }
            if (param.Equals("e2"))
            {
                return Note.e2;
            }
            if (param.Equals("es2"))
            {
                return Note.es2;
            }
            if (param.Equals("f2"))
            {
                return Note.f2;
            }
            if (param.Equals("fis2"))
            {
                return Note.fis2;
            }
            if (param.Equals("ges2"))
            {
                return Note.ges2;
            }
            if (param.Equals("g2"))
            {
                return Note.g2;
            }
            if (param.Equals("as2"))
            {
                return Note.as2;
            }
            if (param.Equals("a2"))
            {
                return Note.a2;
            }
            if (param.Equals("ais2"))
            {
                return Note.ais2;
            }
            if (param.Equals("b2"))
            {
                return Note.b2;
            }
            if (param.Equals("h2"))
            {
                return Note.h2;
            }
            if (param.Equals("c3"))
            {
                return Note.c3;
            }
            if (param.Equals("d3"))
            {
                return Note.d3;
            }
            if (param.Equals("e3"))
            {
                return Note.e3;
            }
            if (param.Equals("f3"))
            {
                return Note.f3;
            }
            else
            {
                return Note.leer;
            }
        }
    }
}
