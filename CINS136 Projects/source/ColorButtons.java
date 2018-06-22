/*
 Dmitry Post
 Whats my color assignment p. 371
 10/22/2012
 ColorButtons.java
 Changes the background color of frame upon selection of radio color
*/
import java.awt.*;
import java.awt.event.*;
import java.lang.reflect.Field;
import javax.swing.*;
public class ColorButtons implements ItemListener
{
  JFrame frame = new JFrame("What's My Color?");
  JPanel panel = new JPanel();
  ButtonGroup colorsGroup = new ButtonGroup();
  JRadioButton radioBoxArray[] = {new JRadioButton("blue"),new JRadioButton("red"),new JRadioButton("yellow"),new JRadioButton("pink"),new JRadioButton("gray")};
  ColorButtons()
  {
    for(int i = 0; i<5; i++)
    {
       panel.add(radioBoxArray[i]);
       colorsGroup.add(radioBoxArray[i]);
       radioBoxArray[i].addItemListener(this);
    }
    frame.add(panel);
    frame.pack();
    frame.setVisible(true);
    frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
  }
  public void itemStateChanged(ItemEvent ie)
  {
      Color color = null;
      find:
      {
      for(int i = 0; i < 5;i++)
      {
	  if(radioBoxArray[i].isSelected())//to find the selected color checkbox
	  {
		try
		{ // converts the text of the checkedbox to a color
		    Field field = Color.class.getField(radioBoxArray[i].getText());
		    color = (Color)field.get(null);
		    panel.setBackground(color);
		}
		catch (Exception e){}
		break find;
	  }
      }
      }
      for(int i = 0; i < 5;i++)
      {
	  panel.getComponent(i).setBackground(color);
      }
  }
  public static void main(String[] args)
  {
    new ColorButtons();
  }
}