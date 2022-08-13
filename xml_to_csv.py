filename = 'c:/BigData/Generic_99-012-X2011033.xml' # file source
output_filename = 'c:/BigData/newData.csv' # output file.

curr_row = {}   # dictionary
count = 0
with open(output_filename, 'w') as output_file:
    header = "GEO\tSex\tAGEGR5\tNOC2011\tCOWD\n" # put the hear at the firt line of csv file
    output_file.write(header)   #write the header
    with open(filename, 'r') as f:  # open the file to be read
        for line in f:      # starting the loop to filter and store data to csv file
            line = line.strip()
            if line == "<generic:SeriesKey>": # new row
                curr_row = {}
            if line.startswith("<generic:Value"): # row column
                quotes_location = [i for i in range(len(line)) if line[i] =='"']
                curr_row[line[quotes_location[0]+1: quotes_location[1]]] = line[quotes_location[2]+1: quotes_location[3]]
            if line == "</generic:SeriesKey>": # end of row
                result = f"{curr_row['GEO']},{curr_row['Sex']},{curr_row['AGEGR5']},{curr_row['NOC2011']},{curr_row['COWD']}\n" # save the data with ',' splitter
                output_file.write(result) # write the result 

                #count += 1                      # counter to check how many rows has been parsed
                #if count % 100000 == 0:
                    #print('parsed rows:', count)