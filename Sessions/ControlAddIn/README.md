
# Customize Business Central UI with Control AddIns

This guide explains how to use Control AddIns in Business Central to customize the user interface by integrating JavaScript. Control AddIns allow you to create rich, interactive components that enhance the user experience within the Business Central environment.

For detailed documentation, see the [Microsoft Learn Docs](https://learn.microsoft.com/en-us/dynamics365/business-central/dev-itpro/developer/devenv-control-addin-style) and explore [Best Practices](https://learn.microsoft.com/en-us/dynamics365/business-central/dev-itpro/developer/devenv-control-addin-bestpractices).

## What is a Control AddIn?

### Overview
A Control AddIn is a custom control or visual element in Business Central, allowing developers to extend the functionality of pages and provide a more interactive experience. They can be used to display web content, visualize data in charts, maps, or other custom formats, and interact with Business Central data.

### Key Features
1. **Custom UI Elements:** Control AddIns enable the creation of custom UI elements that can be embedded directly into Business Central pages.
2. **Interactive Data Visualization:** You can use Control AddIns to create dynamic charts, graphs, and maps that provide users with real-time data visualization.
3. **Event Handling:** Control AddIns can respond to user interactions such as clicks or inputs, triggering AL code that can update data or perform actions within Business Central.
4. **Data Exchange:** Control AddIns can exchange data with the Dynamics 365 server using various data types, making it possible to integrate external data sources or APIs.

### Example Use Cases
- **Custom Dashboards:** Use Control AddIns to create interactive dashboards that display key performance indicators (KPIs) and allow users to filter and manipulate data in real time.
- **Enhanced Data Entry:** Create custom forms or input controls that provide a more intuitive data entry experience, including features like auto-complete, validation, and complex input types.
- **Embedded Applications:** Integrate third-party applications or custom web apps directly into Business Central pages, providing a seamless user experience.


## Example of a Custom Control AddIn in Business Central

The structure of a typical Business Central project with a custom Control AddIn might look like this:

```md
Custom BC Project
├── .alpackages
├── .snapshots
├── .vscode
├── src
│   ├── table
│   ├── page 
│   ├── ...
│   └── controladdin
│       └── HelloWorld
│           ├── js
│           │   └── index.js
│           ├── css
│           │   └── index.css
│           └── ControlAddIn.HelloWorld.al
├── app.json
└── Default Publisher_Custom BC Project.app
```

### File Breakdown
- **index.js:** Contains the JavaScript code that defines the behavior and interaction logic of the Control AddIn.
- **index.css:** Provides custom styling to ensure the Control AddIn integrates smoothly with the Business Central UI.
- **ControlAddIn.HelloWorld.al:** This AL file defines the Control AddIn object in Business Central, specifying the properties, events, and integration points.


## Prerequisite Knowledge

Before working with Control AddIns, you should be familiar with the following:

- **Web Technologies:** Basic knowledge of HTML, CSS, and JavaScript is essential. If you’re new to these technologies, explore the [Mozilla Developer Web](https://developer.mozilla.org/en-US/docs/Learn) tutorials.
- **AL Language:** Familiarity with AL programming is crucial, especially if you’re new to the Control AddIn object. Learn the [Basics of Control AddIn](https://learn.microsoft.com/en-us/dynamics365/business-central/dev-itpro/developer/devenv-control-addin-object) to get started.


## Setup

### Step-by-Step Guide
1. **Creating a Control AddIn:**
   - Typically, the AL AZ Wizard is used to create objects in Business Central projects. However, creating a Control AddIn requires manual setup.
   - Start by creating a new AL file in your project. You can use snippets to help with the initial setup by typing the command `tcontroladdin`, which provides a template for creating a Control AddIn.

2. **Adding JavaScript:**
   - Create a JavaScript file (`.js`) and place it in the same directory as your Control AddIn AL file. This script will define the logic and behavior of your custom control.

3. **Styling Your Control AddIn:**
   - Use a CSS file (`.css`) to style your Control AddIn, ensuring it matches the look and feel of the Business Central environment.

4. **Registering and Using the Control AddIn:**
   - Once your Control AddIn is defined and your scripts are in place, register it within your Business Central page by referencing the Control AddIn object. This allows you to embed the custom control directly into Business Central pages and leverage its functionality.

### Best Practices
- **Performance Optimization:** Ensure your JavaScript is optimized for performance to avoid slowdowns in the Business Central UI.
- **Responsive Design:** Use responsive design techniques in your CSS to ensure the Control AddIn looks good on different devices and screen sizes.
- **Error Handling:** Implement robust error handling in your JavaScript code to manage unexpected behaviors and enhance user experience.


## Conclusion

Control AddIns offer a powerful way to extend and customize the Business Central UI, providing users with enhanced interactive experiences. By following the setup guide and best practices, you can create custom controls that integrate seamlessly with Business Central, offering new capabilities and improving overall productivity.
