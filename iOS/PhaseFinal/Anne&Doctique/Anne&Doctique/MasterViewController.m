//
//  MasterViewController.m
//  Anne&Doctique
//
//  Created by Kapi on 01/07/2014.
//  Copyright (c) 2014 Lionel. All rights reserved.
//

#import "MasterViewController.h"
#import "DetailViewController.h"
#import "AnneAirViewController.h"
#import "AnneMenuViewController.h"
#import "AnneProduct.h"
#import "AnneProductViewCell.h"

@interface MasterViewController () {
    NSMutableArray *_objects;
}
@property (weak, nonatomic) IBOutlet AnneProductViewCell *cell;
@end
//Json's Url
static NSString *jsonUrl=@"http:ralf-esgi.com/app6/servicehello.svc/CNF_RetreiveAnecdote/top/1";
//dictionary of entries
static NSDictionary *result=nil;
//Current page
static 	int currentPage;
//Current Category
static NSString *currentCategory;



@implementation MasterViewController

- (void)awakeFromNib
{
    [super awakeFromNib];
}

- (void)viewDidLoad
{
    [super viewDidLoad];
	// Do any additional setup after loading the view, typically from a nib.
    /*self.navigationItem.leftBarButtonItem = self.editButtonItem;

    UIBarButtonItem *addButton = [[UIBarButtonItem alloc] initWithBarButtonSystemItem:UIBarButtonSystemItemAdd target:self action:@selector(insertNewObject:)];
    self.navigationItem.rightBarButtonItem = addButton;
    */
    AnneMenuViewController * AnneMenu = [[AnneMenuViewController alloc] init];
    NSLog(@"%@",jsonUrl);
    
    //
	// Change the properties of the imageView and tableView (these could be set
	// in interface builder instead).
	//
	//tableView.separatorStyle = UITableViewCellSeparatorStyleNone;
	//tableView.rowHeight = 100;
	//tableView.backgroundColor = [UIColor clearColor];
	
	// Do any additional setup after loading the view, typically from a nib.
    //self.navigationItem.leftBarButtonItem = self.editButtonItem;
    UIButton * button = [UIButton buttonWithType:UIButtonTypeCustom];
    button.frame = CGRectMake(0, 0, 50, 35);
    [button setTitle:@"Menu" forState:UIControlStateNormal];
    [button setTitleColor:[UIColor redColor] forState:UIControlStateNormal];
    [button setTitleColor:[UIColor blueColor] forState:UIControlStateHighlighted];
    [button addTarget:self action:@selector(leftButtonTouch) forControlEvents:UIControlEventTouchUpInside];
    self.navigationItem.leftBarButtonItem = [[UIBarButtonItem alloc] initWithCustomView:button];
    
    typeof(self) bself = self;
    self.AnneSwipeHander = ^{
        [bself.airViewController showAirViewFromViewController:bself.navigationController complete:nil];
    };
    
    
    /*UIBarButtonItem *addButton = [[UIBarButtonItem alloc] initWithBarButtonSystemItem:UIBarButtonSystemItemAdd target:self action:@selector(insertNewObject:)];
    self.navigationItem.rightBarButtonItem = addButton;
    */
    ////////////////
    //-- Make URL request with server
    NSHTTPURLResponse *response = nil;
    NSString *jsonUrlString = [NSString stringWithFormat:jsonUrl];//@"http:ralf-esgi.com/app6/servicehello.svc/VDM_RetreiveAnecdote/top/1"];
    NSURL *url = [NSURL URLWithString:[jsonUrlString stringByAddingPercentEscapesUsingEncoding:NSUTF8StringEncoding]];
    
    //-- Get request and response though URL
    NSURLRequest *request = [[NSURLRequest alloc]initWithURL:url];
    NSData *responseData = [NSURLConnection sendSynchronousRequest:request returningResponse:&response error:nil];
    
    //-- JSON Parsing
    result = [NSJSONSerialization JSONObjectWithData:responseData options:NSJSONReadingMutableContainers error:nil];
    //NSLog(@"Result = %@",result);
    
    
    for (NSMutableDictionary *dict in result)
    {
        NSString *string = dict[@"Type"];
        NSLog(@"Type = %@",string);
        
        AnneProduct *product = [AnneProduct productWithDictionary:dict];

        //NSMutableArray *Products=[NSMutableArray insert];
        //AnneProductViewCell *ProductCell = [AnneProductViewCell setProducts:product];
        
        /*NSLog(@"Id = %@",product.Id);
        NSLog(@"Agree = %@",product.voteplus);
        NSLog(@"Deserved = %@",product.votemoins);
        NSLog(@"Date = %@",product.date);
        NSLog(@"Author = %@",product.author);
        NSLog(@"Text = %@",product.description);
        NSLog(@"nbcoms = %@",product.nbcoms);
        */
        //AnneProductViewCell *cell
        if (!product)
        {
            NSLog(@"Error in url response");
            
        }
        else
        {
            
            NSLog(@"Json's parsing have been finished");
            //NSData *data = [string dataUsingEncoding:NSUTF8StringEncoding];
            
            //[cell setProduct:product];
            //dic[@"array"] = [NSJSONSerialization JSONObjectWithData:data options:0 error:nil];
            //NSLog(@"ttttttteeeesssssttttt");
        }
    }
    
    
    ////////////////
    NSLog(@"viewDidLoad's MasterViewControler finished");
}

- (void)leftButtonTouch
{
    NSLog(@"leftButtonBeginning");
    [self.airViewController showAirViewFromViewController:self.navigationController complete:nil];
    NSLog(@"leftButtonfinished");
}

- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (void)insertNewObject:(id)sender
{
    if (!_objects) {
        _objects = [[NSMutableArray alloc] init];
    }
    [_objects insertObject:[NSDate date] atIndex:0];
    NSIndexPath *indexPath = [NSIndexPath indexPathForRow:0 inSection:0];
    [self.tableView insertRowsAtIndexPaths:@[indexPath] withRowAnimation:UITableViewRowAnimationAutomatic];
}

-(void) removeOldEntries {
	NSMutableArray *indexPaths = [NSMutableArray array];
	
	for (int i = 0; i < entries.count; i++) {
		[indexPaths addObject:[NSIndexPath indexPathForRow:i inSection:0]];
	}
	
	//SafeRelease(entries);
	[tableView deleteRowsAtIndexPaths:indexPaths withRowAnimation:UITableViewRowAnimationRight];
}

-(void) addNewEntries:(BOOL) animated {
	NSMutableArray *indexPaths = [NSMutableArray array];
	
	for (int i = [tableView numberOfRowsInSection:0]; i < entries.count; i++) {
		[indexPaths addObject:[NSIndexPath indexPathForRow:i inSection:0]];
	}
    
	[tableView insertRowsAtIndexPaths:indexPaths withRowAnimation:animated ? UITableViewRowAnimationLeft : UITableViewRowAnimationNone];
}

-(void) addNew:(BOOL) animated {
	NSMutableArray *indexPaths = [NSMutableArray array];
	
	for (int i = [tableView numberOfRowsInSection:0]; i < entries.count; i++) {
		[indexPaths addObject:[NSIndexPath indexPathForRow:i inSection:0]];
	}
    
	[tableView insertRowsAtIndexPaths:indexPaths withRowAnimation:animated ? UITableViewRowAnimationLeft : UITableViewRowAnimationNone];
}
#pragma mark - Table View

- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView
{
    return 1;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section
{
    return result.count;
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
   /* UITableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:@"Cell" forIndexPath:indexPath];

    NSDate *object = _objects[indexPath.row];
    cell.textLabel.text = [object description];
    */
    //NSArray* list = [self result listForItemAtIndex:indexPath.row];//objectForKey: [NSString numberWithInt:indexPath.dict] ];
    
    static NSString *CellId = @"Cell";
     AnneProductViewCell * cell = (AnneProductViewCell *)[tableView dequeueReusableCellWithIdentifier:CellId];
     if(!cell)
     {
     cell = [[AnneProductViewCell alloc]initWithStyle:UITableViewCellStyleDefault reuseIdentifier:CellId];
     }
    
    //NSDictionary *anne = [ result objectAtIndex:indexPath.row];
    //////////////////////
    //
    //
    //La modification pour les mise en cellule
    cell.author.text = result[@"Author"];//[anne  objectForKey:@"Author"];
    cell.text.text = result[@"Text"];//[anne objectForKey:@"Text"];
    cell.date.text= result[@"Date" ];//[anne objectForKey:@"Date"];
    //[cell setProduct:[result objectAtIndex:indexPath.row]];
     //[cell setProduct:(AnneProduct*) product];
     
     //[AnneProductViewCell configureWithText:[NSString stringWithFormat:@"Author %zd", indexPath.row]];
    
    //NSLog(@"%@",result);
    /*for (NSMutableDictionary *dict in result)
    {
        NSString *string = dict[@"Type"];
        NSLog(@"Type = %@",indexPath);
        
        AnneProduct *product = [AnneProduct productWithDictionary:dict];
        
        [cell : (NSString*)product.author];
         
        [cell configureWithTextDescription: (NSString*)product.description];
        [cell configureWithTextDate: (NSString*)product.date];
        NSString *productAuthor=product.author;
        NSString *productDescription=product.description;
     
        //[cell configureWithText:(NSString*)productAuthor andDate:(NSString*)productDate andText:(NSString*)productDescription];
        [cell setProduct: (AnneProduct*)product];
        NSLog(@"---------------------------");
        NSLog(@"id = %@",product.Id);
        //NSLog(@"Author = %@",product.author);
        //NSLog(@"date = %@",product.date);
        //NSLog(@"description = %@",product.description);
    }
    
    
    NSString *test =@"clic";
    [cell author:[[NSString nom] objectAtIndex:indexPath]];
    */return cell;
    
   /*  const NSInteger TOP_LABEL_TAG = 1001;
     const NSInteger BOTTOM_LABEL_TAG = 1002;
     UILabel *author;
     UILabel *date;
    static NSString *CellId = @"cell";
    AnneProductViewCell * cell = (AnneProductViewCell *)[tableView dequeueReusableCellWithIdentifier:CellId];
    if(!cell)
    {
        cell = [[AnneProductViewCell alloc]initWithStyle:UITableViewCellStyleDefault reuseIdentifier:CellId];
    }
    
    author.tag = TOP_LABEL_TAG;
    author.backgroundColor = [UIColor clearColor];
    //author.textColor = [UIColor colorWithRed:0.25 green:0.0 blue:0.0 alpha:1.0];
    author.highlightedTextColor = [UIColor colorWithRed:1.0 green:1.0 blue:0.9 alpha:1.0];
    author.font = [UIFont systemFontOfSize:[UIFont labelFontSize]];
    
    date.tag = BOTTOM_LABEL_TAG;
    date.backgroundColor = [UIColor clearColor];
    //date.textColor = [UIColor colorWithRed:0.25 green:0.0 blue:0.0 alpha:1.0];
    date.highlightedTextColor = [UIColor colorWithRed:1.0 green:1.0 blue:0.9 alpha:1.0];
    date.font = [UIFont systemFontOfSize:[UIFont labelFontSize] - 2];
    
		author = (UILabel *)[cell viewWithTag:TOP_LABEL_TAG];
		date = (UILabel *)[cell viewWithTag:BOTTOM_LABEL_TAG];
	
	author.text = [NSString stringWithFormat:@"Cell at row %ld.", [indexPath row]];
	date.text = [NSString stringWithFormat:@"Some other information.", [indexPath row]];
    
    return cell;*/
}
/*
-(UITableViewCell*)tableView:(UITableView*)tableView cellForRowAtIndexPath:(NSIndexPath*)indexPath
{
    
    NSArray* listOfAllElementsInSection = [self.sections objectForKey: [NSNumber numberWithInt:indexPath.section] ];
    
    
    static NSString *CellIdentifier = @"MunicipalCell";
    
    MunicipalCell *cell = (MunicipalCell*)[tableView dequeueReusableCellWithIdentifier:CellIdentifier];
    if (cell == nil) {
        
	    NSArray *xib = [[NSBundle mainBundle] loadNibNamed:@"MunicipalCell" owner:self options:nil];
        
	    for (id oneObject in xib) {
            
		    if ([oneObject isKindOfClass:[MunicipalCell class]]) {
			    cell = (MunicipalCell *)oneObject;
		    }
	    }
    }
    
    
    
    NSDictionary *movie = [listOfAllElementsInSection objectAtIndex:indexPath.row];
    
    cell.nom.text = [movie objectForKey:@"nom"];
    cell.foncion.text = [movie objectForKey:@"fonction"];
    
    return cell;
}*/

- (BOOL)tableView:(UITableView *)tableView canEditRowAtIndexPath:(NSIndexPath *)indexPath
{
    // Return NO if you do not want the specified item to be editable.
    return YES;
}

- (void)tableView:(UITableView *)tableView commitEditingStyle:(UITableViewCellEditingStyle)editingStyle forRowAtIndexPath:(NSIndexPath *)indexPath
{
    if (editingStyle == UITableViewCellEditingStyleDelete) {
        [_objects removeObjectAtIndex:indexPath.row];
        [tableView deleteRowsAtIndexPaths:@[indexPath] withRowAnimation:UITableViewRowAnimationFade];
    } else if (editingStyle == UITableViewCellEditingStyleInsert) {
        // Create a new instance of the appropriate class, insert it into the array, and add a new row to the table view.
    }
}

/*
// Override to support rearranging the table view.
- (void)tableView:(UITableView *)tableView moveRowAtIndexPath:(NSIndexPath *)fromIndexPath toIndexPath:(NSIndexPath *)toIndexPath
{
}
*/

/*
// Override to support conditional rearranging of the table view.
- (BOOL)tableView:(UITableView *)tableView canMoveRowAtIndexPath:(NSIndexPath *)indexPath
{
    // Return NO if you do not want the item to be re-orderable.
    return YES;
}
*/

- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender
{
    if ([[segue identifier] isEqualToString:@"showDetail"]) {
        NSIndexPath *indexPath = [self.tableView indexPathForSelectedRow];
        NSDate *object = _objects[indexPath.row];
        [[segue destinationViewController] setDetailItem:object];
    }
}

@end
