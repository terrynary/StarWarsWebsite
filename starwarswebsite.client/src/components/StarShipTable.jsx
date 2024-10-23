import { useEffect, useState } from 'react';
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import AddIcon from '@mui/icons-material/Add';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/DeleteOutlined';
import SaveIcon from '@mui/icons-material/Save';
import CancelIcon from '@mui/icons-material/Close';
import {
    GridRowModes,
    DataGrid,
    GridToolbarContainer,
    GridActionsCellItem,
    GridRowEditStopReasons,
  } from '@mui/x-data-grid';

  function EditToolbar(props) {
    const { setRows, setRowModesModel } = props;
  
    const handleClick = () => {
      const id = props.rows.length+1;
      setRows((oldRows) => [
        ...oldRows,
        { id,name: '', model: '', starship_class: '', length: '',  cost_In_Credits: ''},
      ]);
      setRowModesModel((oldModel) => ({
        ...oldModel,
        [id]: { mode: GridRowModes.Edit, fieldToFocus: 'name' },
      }));
    };
  
    return (
      <GridToolbarContainer>
        <Button color="primary" startIcon={<AddIcon />} onClick={handleClick}>
          Add record
        </Button>
      </GridToolbarContainer>
    );
  }

function StarShipTable() {
    const [rows, setRows] = useState();
    const [rowModesModel, setRowModesModel] = useState({});
    const [luckyStarShip, setLuckyStarShip] = useState('');
    
    
    const handleRowEditStop = (params, event) => {
      if (params.reason === GridRowEditStopReasons.rowFocusOut) {
        event.defaultMuiPrevented = true;
      }
    };
  
    const handleEditClick = (id) => {
      setRowModesModel({ ...rowModesModel, [id]: { mode: GridRowModes.Edit } });
    };
  
    const handleSaveClick = (id) => {
      setRowModesModel({ ...rowModesModel, [id]: { mode: GridRowModes.View } });
      
    };
  
    const handleDeleteClick = (id) => () => {
      setRows(rows.filter((row) => row.id !== id));
      deleteStarShip(id);
    };
  
    const handleCancelClick = (id) => () => {
      setRowModesModel({
        ...rowModesModel,
        [id]: { mode: GridRowModes.View, ignoreModifications: true },
      });
  
      const editedRow = rows.find((row) => row.id === id);
      if (editedRow.isNew) {
        setRows(rows.filter((row) => row.id !== id));
      }
    };
  
    const processRowUpdate = (newRow) => {
      const updatedRow = { ...newRow, isNew: false };
      const found = rows.find((row) => row.id === newRow.id);
      console.log(found);
      if(found.name === "") {
        delete newRow.id;
        createStarShip(newRow);
      }
      else {
        updateStarShip(newRow);
      }
      setRows(rows.map((row) => (row.id === newRow.id ? updatedRow : row)));
      return updatedRow;
    };
  
    const handleRowModesModelChange = (newRowModesModel) => {
      setRowModesModel(newRowModesModel);
    };

    useEffect(() => {
        populateStarShipData();
    }, []);

    const columns = [
        { field: 'name', headerName: 'Name', width: 220, editable: true },
        {
          field: 'model',
          headerName: 'Model',
          width: 250,
          align: 'left',
          headerAlign: 'left',
          editable: true,
        },
        {
          field: 'starship_Class',
          headerName: 'Star Ship Class',
          width: 250,
          editable: true,
        },
        {
          field: 'length',
          headerName: 'Length',
          width: 80,
          editable: true,
        },
        {
          field: 'cost_In_Credits',
          headerName: 'Cost In Credits',
          width: 80,
          editable: true,
        },
        {
          field: 'actions',
          type: 'actions',
          headerName: 'Actions',
          width: 80,
          cellClassName: 'actions',
          getActions: ({ id }) => {
            const isInEditMode = rowModesModel[id]?.mode === GridRowModes.Edit;
    
            if (isInEditMode) {
              return [
                <GridActionsCellItem
                  icon={<SaveIcon />}
                  label="Save"
                  sx={{
                    color: 'primary.main',
                  }}
                  onClick={() => handleSaveClick(id)}
                />,
                <GridActionsCellItem
                  icon={<CancelIcon />}
                  label="Cancel"
                  className="textPrimary"
                  onClick={() => handleCancelClick(id)}
                  color="inherit"
                />,
              ];
            }
    
            return [
              <GridActionsCellItem
                icon={<EditIcon />}
                label="Edit"
                className="textPrimary"
                onClick={() => handleEditClick(id)}
                color="inherit"
              />,
              <GridActionsCellItem
                icon={<DeleteIcon />}
                label="Delete"
                onClick={handleDeleteClick(id)}
                color="inherit"
              />,
            ];
          },
        },
      ];
    const contents = rows === undefined
        ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
        : <Box
            sx={{
            height: 500,
            width: '100%',
            '& .actions': {
                color: 'text.secondary',
            },
            '& .textPrimary': {
                color: 'text.primary',
            },
            bgcolor: 'background.paper',
            }}
        >
        <DataGrid
          rows={rows}
          columns={columns}
          editMode="row"
          rowModesModel={rowModesModel}
          onRowModesModelChange={handleRowModesModelChange}
          onRowEditStop={handleRowEditStop}
          processRowUpdate={processRowUpdate}
          slots={{
            toolbar: EditToolbar,
          }}
          slotProps={{
            toolbar: { setRows, setRowModesModel, rows },
          }}
        />
        </Box>
    return (
        <div>
            <h1 id="tableLabel">Star Wars Star Ships</h1>
            <h2>Lucky Star Ship is: {luckyStarShip.name}</h2>
            <img
            src = 'http://static.wikia.nocookie.net/starwars/images/c/c7/Aa9coruscantfreighter.jpg/revision/latest?cb=20091201131352'
            alt = 'placeholder'
            />
            {contents}
        </div>
    );

    async function populateStarShipData() {
        const response = await fetch('http://localhost:7098/starShips');
        const data = await response.json();
        setRows(data);
        populateLuckyStarShip();
    }

    async function populateLuckyStarShip() {
      const response = await fetch('http://localhost:7098/luckyStarShip');
      const data = await response.json();
      setLuckyStarShip(data);
    }
    
    async function updateStarShip(row){
      const response = await fetch('http://localhost:7098/updateStarShip/'+ row.id, {
        method: 'PUT',
        headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(row)
      });
      const data = await response.json();
      alert(data);
    }

    async function deleteStarShip(id){
      const response = await fetch('http://localhost:7098/deleteStarShip/'+ id, {
        method: 'DELETE',
        headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        },
      });
      const data = await response.json();
      alert(data);
    }

    async function createStarShip(row){
      const response = await fetch('http://localhost:7098/createStarShip', {
        method: 'POST',
        headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(row)
      });
      const data = await response.json();
      alert(data);
    }
}

export default StarShipTable;