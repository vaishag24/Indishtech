using System;using System.Collections.Generic;
using System.IO;using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;namespace SimpleCalculator{    public partial class FrmSimpleCalculator : Form    {        public FrmSimpleCalculator()        {            InitializeComponent();        }        private void Form1_Load(object sender, EventArgs e)        {        }                public void btnBrowse_Click(object sender, EventArgs e)//Button to browse to the input file        {                                         OpenFileDialog open = new OpenFileDialog();//funtion for the open prompt            try            {                                if (open.ShowDialog() == DialogResult.OK )//When the user chooses the file and clicks open the file is opened                {                   StreamReader read = new StreamReader(File.OpenRead(open.FileName));//function to open the browsed file and read all the contents 

                    DirectoryInfo directory=new DirectoryInfo(open.FileName);//returns the full path of the file + filename +.txt
                    string filePath = Convert.ToString(directory);//converts info to string

                    filePath=filePath.Remove(filePath.LastIndexOf('\\'));//removes the filename and extension after //

                    

                    StreamWriter write = new StreamWriter(filePath+"\\"+"result.txt");//function to create a txt file in path where file exits and write the results. 
                
                    var lineCount = File.ReadAllLines(open.FileName).Length;//funtion to count the total lines of inputs                   

                    for (int i=0 ; i<lineCount ; i++)//for loop to read the inputs as well as write in the txt file
                 
                    {
                        string input = read.ReadLine();// reads the ith lines of the txt file
                        string[] sides=input.Split(',');//splits the string based on "," and stores in array as 2 inputs

                       double sideA= double.Parse(sides[0]);
                       double sideB= double.Parse(sides[1]);

                        txtSideA.Text = sideA.ToString();
                        txtSideB.Text = sideB.ToString();

                        //calculates area using 2 sides and writes in the file
                        string result=Convert.ToString(calcArea(sideA, sideB));
                        txtResult.Text = result;    

                        write.WriteLine(result);
                       

                    }                        read.Close();//close the input txt file                        read.Dispose();                        write.Close();//close the ouput file                }            }            catch (Exception ex)             {                Console.WriteLine(ex.Message);            }

        }
        
        //Function to calculate right angle triangle using 2 sides as parameters
        public double calcArea(double sideA,double sideB)
        {
            double area = 0;
            area= 0.5*sideA*sideB;
            return area;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }}